using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Money { get; private set; }

    private PlayerUI playerUI;

    private void Start()
    {
        MaxHealth = 100;
        Health = MaxHealth;

        playerUI = GetComponent<PlayerUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
            CollectCoin(collision);

        if (collision.gameObject.tag == "Item")
            CollectItem();
    }

    public void TakeDamage(int damage)
    {
        var movementScript = GetComponent<PlayerMovement>();

        if (movementScript.IsDashing)
            return;

        Health -= damage;
        playerUI.UpdateHealthBar();
    }

    public void RestoreHealth(int restoreValue)
    {
        Health += restoreValue;
    }

    private void CollectCoin(Collider2D collision)
    {
        var coinClass = collision.gameObject.GetComponent<Coin>();
        Money += coinClass.GetCollected();
        playerUI.UpdateMoneyLabel();
    }

    private void CollectItem()
    {

    }
}
