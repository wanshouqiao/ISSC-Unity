using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrontSwitcher : MonoBehaviour
{
    // ͨ��Inspectorָ��ģ�������
    public Camera templateCamera;
    private Camera activeCamera;

    void Start()
    {
        activeCamera = GetComponent<Camera>(); // ���ڵ�ǰ��������
    }

    public void CopyCameraParameters()
    {
        if (templateCamera == null) return;

        // ����Transform������λ�ú���ת��
        activeCamera.transform.position = templateCamera.transform.position;
        activeCamera.transform.rotation = templateCamera.transform.rotation;
        /*
        // ����Camera������Ĳ���
        activeCamera.fieldOfView = templateCamera.fieldOfView;
        activeCamera.nearClipPlane = templateCamera.nearClipPlane;
        activeCamera.farClipPlane = templateCamera.farClipPlane;
        activeCamera.orthographic = templateCamera.orthographic;
        activeCamera.orthographicSize = templateCamera.orthographicSize;
        activeCamera.clearFlags = templateCamera.clearFlags;
        activeCamera.backgroundColor = templateCamera.backgroundColor;

        // ��ѡ��������������������ò㡢��Ⱦ·���ȣ�
        activeCamera.cullingMask = templateCamera.cullingMask;
        activeCamera.renderingPath = templateCamera.renderingPath;
        */
    }
}
