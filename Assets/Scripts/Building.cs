using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Color mouseENTER;

    private Color defaultColor;

    private Renderer renderer;

    void OnMouseEnter()
    {
        renderer.material.color = mouseENTER;
    }

    void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }

}
