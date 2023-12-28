using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [HideInInspector] public bool isBasementKeyGet;
    [HideInInspector] public bool isMorgueKeyGet;
    [HideInInspector] public bool isMainKeyGet;


    private void Awake()
    {
        Instance = this;
        ItemSet();
    }

    private void ItemSet()
    {
        isBasementKeyGet = false;
        isMorgueKeyGet = false;
        isMainKeyGet = false;
    }
}
