using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CameraMoveByFrontend : MonoBehaviour
{
    [Header("DOTween Settings")]
    public Ease moveEase = Ease.Unset;
    public float moveDuration = 0.7f;
    public float rotationSpeed = 0.2f;


    [Header("Viewport Settings")]
    [Range(0.1f, 2f)] public float viewportPadding = 2f;
    public LayerMask obstacleLayer;


    private Camera _mainCam;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private Tween _activeTween;

    void Start() => _mainCam = Camera.main;

    public void MoveCamera()
    {
        FocusCamera(this.transform);
    }

    void FocusCamera(Transform target)
    {


        // ��ֹ���ж���
        _activeTween?.Kill();

        // ��������λ�ú���ת
        Bounds bounds = GetPreciseBounds(target);
        Vector3 targetCenter = bounds.center;
        Vector3 targetPos = CalculateCameraPosition(bounds);
        Quaternion targetRot = Quaternion.LookRotation(targetCenter - targetPos);

        // ��̬���ϼ��
        if (Physics.Linecast(targetCenter, targetPos, obstacleLayer))
        {
            targetPos = GetAdjustedPosition(targetCenter, targetPos);
        }

        // DOTween��������
        Sequence focusSequence = DOTween.Sequence()
            .Append(_mainCam.transform.DOMove(targetPos, moveDuration)
                .SetEase(moveEase)
                .OnUpdate(() => UpdateRotation(targetCenter)) // ��̬��ת����
            )
            .Join(_mainCam.transform.DORotateQuaternion(targetRot, moveDuration * 0.8f)
                .SetEase(Ease.OutSine)
            )
            .OnStart(() => {
                _originalPosition = _mainCam.transform.position;
                _originalRotation = _mainCam.transform.rotation;
            })
            .OnComplete(() => FinalCalibration(targetCenter));

        _activeTween = focusSequence;

    }

    Vector3 CalculateCameraPosition(Bounds bounds)
    {
        // ������ͼͶӰ����
        Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0);
        Vector3 targetDirection = _mainCam.transform.rotation * Vector3.forward;

        // ��̬�������
        float distance = CalculateOptimalDistance(bounds);
        return bounds.center - targetDirection * distance * viewportPadding;
    }

    void UpdateRotation(Vector3 targetCenter)
    {
        // ʵʱ�������
        Quaternion currentRot = _mainCam.transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(targetCenter - _mainCam.transform.position);
        _mainCam.transform.rotation = Quaternion.Slerp(currentRot, targetRot, rotationSpeed * Time.deltaTime);
    }

    void FinalCalibration(Vector3 targetCenter)
    {
        // ����У׼����ֹ�ۼ���
        Vector3 screenPos = _mainCam.WorldToScreenPoint(targetCenter);
        Vector3 offset = new Vector3(
            screenPos.x - Screen.width / 2f,
            screenPos.y - Screen.height / 2f,
            0
        );

        // ΢������
        if (offset.magnitude > 2f)
        {
            _mainCam.transform.DOMove(_mainCam.transform.position -
                _mainCam.transform.TransformVector(offset / 100f), 0.3f);
        }
    }

    Vector3 GetAdjustedPosition(Vector3 targetCenter, Vector3 originalPos)
    {
        // �ϰ���ر��㷨
        if (Physics.SphereCast(targetCenter, 0.5f, (originalPos - targetCenter).normalized,
            out RaycastHit hit, Vector3.Distance(targetCenter, originalPos)))
        {
            return hit.point + hit.normal * 0.5f;
        }
        return originalPos;
    }

    Bounds GetPreciseBounds(Transform root)
    {
        // ���������Ӷ���ľ�ȷ��Χ��
        Renderer[] renderers = root.GetComponentsInChildren<Renderer>();
        Bounds bounds = renderers[0].bounds;
        foreach (Renderer r in renderers) bounds.Encapsulate(r.bounds);
        return bounds;
    }

    float CalculateOptimalDistance(Bounds bounds)
    {
        // ������׶�������Ѿ���
        float fovRad = _mainCam.fieldOfView * Mathf.Deg2Rad;
        float maxSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
        return maxSize / (2f * Mathf.Tan(fovRad / 2f));
    }
}

