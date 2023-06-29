using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer SpriteRender;
    private BoxCollider2D BoxCollider;

    private void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    public void Collected()
    {
        var inventoryManager = GameObject.FindGameObjectsWithTag("Player")[0]
            .GetComponent<InventoryManager>();

        if (inventoryManager.IsInvenoryFull())
        {
            Debug.Log("Inventory is Full");
            return;
        }

        gameObject.transform.parent = inventoryManager.Inventory.transform;
        transform.localScale = new Vector2(0, 0);

        SpriteRender.enabled = false;
        BoxCollider.enabled = false;
    }

    public void Dropped()
    {
        SpriteRender.enabled = true;
        BoxCollider.enabled = true;

        transform.parent = null;
    }
}
