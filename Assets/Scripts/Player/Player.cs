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
        Health -= damage;
        playerUI.UpdateHealthBar();
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
