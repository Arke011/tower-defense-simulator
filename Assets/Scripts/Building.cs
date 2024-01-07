using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Color mouseENTER;

    private Color defaultColor;

    private Renderer renderer;

    private GameObject tower;

    public Vector3 offset;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        renderer.material.color = mouseENTER;
    }

    void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("clear visible lack of pure skill");
            return;
        }

        GameObject towerToBuild = GameManager.instance.GETtowerNeeded();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + offset, transform.rotation);
    }

}
