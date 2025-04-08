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

    public bool isListening = false;  // �Ƿ����ü���

    void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
        renderers = GetComponentsInChildren<Renderer>();

        // ������ԭʼ��ɫ
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

        if (Input.GetMouseButtonDown(0))  // ���������
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    OnClicked(); // ��������¼�
                }
            }
        }
    }

    public void OnClicked()
    {
        // ��
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
                rend.GetPropertyBlock(propertyBlock, i); // ��ȡ��������
                propertyBlock.SetColor("_Color", Color.red); // ���޸���ɫ
                rend.SetPropertyBlock(propertyBlock, i); // Ӧ���޸�
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
