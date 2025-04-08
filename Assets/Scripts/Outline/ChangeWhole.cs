using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeWhole : MonoBehaviour
{
    //public Button colorButton;
    //public Button resetButton;
    private Renderer[] renderers;
    private List<Color[]> originalColorsList = new List<Color[]>();
    private MaterialPropertyBlock propertyBlock;

    public bool isListening = false;  // 是否启用监听

    void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
        renderers = GetComponentsInChildren<Renderer>();

        // 仅保存原始颜色
        foreach (Renderer rend in renderers)
        {
            Color[] colors = new Color[rend.materials.Length];
            for (int i = 0; i < rend.materials.Length; i++)
            {
                colors[i] = rend.materials[i].color;
            }
            originalColorsList.Add(colors);
        }

        //colorButton.onClick.AddListener(SetAllRed);
        //resetButton.onClick.AddListener(ResetColors);
    }

    private void Update()
    {
        if (!isListening) { return; }

        if (Input.GetMouseButtonDown(0))  // 鼠标左键点击
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    OnClicked(); // 触发点击事件
                }
            }
        }
    }

    public void OnClicked()
    {
        // 将
    }

    public void EnableListening(bool enable)
    {
        isListening = enable;
    }

    public void SetAllRed()
    {
        foreach (Renderer rend in renderers)
        {
            for (int i = 0; i < rend.materials.Length; i++)
            {
                rend.GetPropertyBlock(propertyBlock, i); // 读取现有属性
                propertyBlock.SetColor("_Color", Color.red); // 仅修改颜色
                rend.SetPropertyBlock(propertyBlock, i); // 应用修改
            }
        }
    }

    public void ResetColors()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            Renderer rend = renderers[i];
            Color[] originalColors = originalColorsList[i];
            for (int j = 0; j < rend.materials.Length; j++)
            {
                rend.GetPropertyBlock(propertyBlock, j);
                propertyBlock.SetColor("_Color", originalColors[j]);
                rend.SetPropertyBlock(propertyBlock, j);
            }
        }
    }
}
