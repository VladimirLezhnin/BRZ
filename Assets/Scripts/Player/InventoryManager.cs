using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    private int InventoryLimit = 4;

    void Start()
    {

    }

    private void Update()
    {
        Debug.Log(IsInvenoryFull());
    }

    private bool IsInvenoryFull()
    {
        if (Inventory == null)
            return false;

        if (Inventory.GetComponentsInChildren<Item>().Length >= InventoryLimit)
            return true;

        return false;
    }
}
