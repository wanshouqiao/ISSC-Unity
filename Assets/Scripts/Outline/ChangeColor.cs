using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public GameObject OP;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    public void ChangeColorOn()
    {
        rend.sharedMaterial = material[1];
    }

    public void ChangeColorOff()
    {
        rend.sharedMaterial = material[0];
    }

    /*
    public void ChangeColorOn(string msg)
    {
        OP.GetComponent<Outline>().enabled = true;
    }

    public void ChangeColorOff(string msg)
    {
        OP.GetComponent<Outline>().enabled = false;
    }
    */
}
