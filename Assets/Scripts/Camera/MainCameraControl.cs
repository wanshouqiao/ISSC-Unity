using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    // ��ת�ٶ�
    public float xRotationSpeed = 10f;  // x����ת�ٶ�
    public float yRotationSpeed = 10f;  // y����ת�ٶ�

    // �����ٶ�
    public float scrollSpeed = 100f;

    // ����ƶ��ٶ�
    public float moveSpeed = 100f;

    // ÿ֡���º���
    void Update()
    {
        // ���ô������š���ת���ƶ��ĺ���
        HandleCameraZoom();
        HandleCameraRotation();
        HandleCameraMovement();
    }

    /// <summary>
    /// �����������ת��
    /// ��ס�Ҽ�ʱ�������������ת��
    /// </summary>
    private void HandleCameraRotation()
    {
        // ����Ƿ����Ҽ�
        if (Input.GetMouseButton(1))
        {
            // ��ȡ����X��Y���ƶ���
            float mouseXInput = Input.GetAxisRaw("Mouse X");
            float mouseYInput = Input.GetAxisRaw("Mouse Y");

            // ������ת����
            float xRotationDelta = mouseXInput * xRotationSpeed * 0.02f;
            float yRotationDelta = -mouseYInput * yRotationSpeed * 0.02f;

            // ���ݵ�ǰ�Ƕȶ����������ת
            transform.Rotate(Vector3.up, xRotationDelta, Space.World);    // �����������Y����ת
            transform.Rotate(Vector3.right, yRotationDelta, Space.Self);  // �����������X����ת
        }
    }

    /// <summary>
    /// ������������š�
    /// ʹ�������ֽ���ǰ������˲�����
    /// </summary>
    private void HandleCameraZoom()
    {
        // ��ȡ�����ֵ�����
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // ���ݹ���������������λ��
        Vector3 newCameraPosition = transform.position + transform.forward * scrollInput * scrollSpeed * 100;
        transform.position = newCameraPosition;
    }

    /// <summary>
    /// ����������ƶ���
    /// ��ס�м������������������ƽ�ơ�
    /// </summary>
    private void HandleCameraMovement()
    {
        // ����Ƿ������
        if (Input.GetMouseButton(0))
        {
            // ��ȡ���X��Y�������ֵ
            float mouseXInput = Input.GetAxis("Mouse X");
            float mouseYInput = Input.GetAxis("Mouse Y");

            // ����������ƶ�����
            Vector3 moveDirection = (mouseXInput * -transform.right + mouseYInput * -transform.up);

            // ��������ֵ�ƶ����
            transform.position += moveDirection * moveSpeed * 6;
        }
    }
}