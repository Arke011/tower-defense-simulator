using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject towerNeeded;

    private GameObject towerToBuild;

    public GameObject towerPrefab;

    public GameObject GETtowerNeeded()
    {
        return towerNeeded;
    }
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        towerNeeded = towerPrefab;
    }
}
