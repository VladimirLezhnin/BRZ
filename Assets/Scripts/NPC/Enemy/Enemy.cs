using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name;

    [SerializeField] private int Health;
    private int MaxHealth;

    [SerializeField] private float AttackDodgeChance;

    [SerializeField] private int MoneyDrop;

    private void Start()
    {
        MaxHealth = Health;
    }

    public void TakeDamage(int takenDamage)
    {
        if (AttackDodgeChance != 0 && DodgeAttack())
            return;
            

        Health -= takenDamage;
        if (Health <= 0)
            EnemyKilled();
    }

    private bool DodgeAttack()
    {
        return UnityEngine.Random.Range(0f, 1f) <= AttackDodgeChance;
    }

    private void EnemyKilled()
    {
        if (this.enabled == false)
            return;

        //Мёртвый Спрайт

        var coinsToDrop = CoinPrefab.GetCoins(MoneyDrop);
        foreach (var coin in coinsToDrop)
        {
            var coinXPosition = transform.position.x + UnityEngine.Random.Range(-3f, 3f);
            var coinYPosition = transform.position.y + UnityEngine.Random.Range(-3f, 3f);

            var coinPosition = new Vector2(coinXPosition, coinYPosition);
            Instantiate(coin, coinPosition, Quaternion.identity, transform);
        }

        var scripts = GetComponents<MonoBehaviour>();
        foreach(var script in scripts)
        {
            script.enabled = false;
        }

    }
}
