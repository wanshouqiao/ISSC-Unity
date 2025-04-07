using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrontSwitcher : MonoBehaviour
{
    // 通过Inspector指定模板摄像机
    public Camera templateCamera;
    private Camera activeCamera;

    void Start()
    {
        activeCamera = GetComponent<Camera>(); // 绑定在当前活动摄像机上
    }

    public void CopyCameraParameters()
    {
        if (templateCamera == null) return;

        // 复制Transform参数（位置和旋转）
        activeCamera.transform.position = templateCamera.transform.position;
        activeCamera.transform.rotation = templateCamera.transform.rotation;
        /*
        // 复制Camera组件核心参数
        activeCamera.fieldOfView = templateCamera.fieldOfView;
        activeCamera.nearClipPlane = templateCamera.nearClipPlane;
        activeCamera.farClipPlane = templateCamera.farClipPlane;
        activeCamera.orthographic = templateCamera.orthographic;
        activeCamera.orthographicSize = templateCamera.orthographicSize;
        activeCamera.clearFlags = templateCamera.clearFlags;
        activeCamera.backgroundColor = templateCamera.backgroundColor;

        // 可选：复制其他参数（如剪裁层、渲染路径等）
        activeCamera.cullingMask = templateCamera.cullingMask;
        activeCamera.renderingPath = templateCamera.renderingPath;
        */
    }
}
