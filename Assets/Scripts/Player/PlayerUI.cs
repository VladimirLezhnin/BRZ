using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private TextMeshProUGUI MoneyLabel;
    Player playerStats;

    void Start()
    {
        playerStats = GetComponent<Player>();
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        HealthBar.value = playerStats.Health;
    }

    public void UpdateMoneyLabel()
    {
        MoneyLabel.text = playerStats.Money.ToString();
    }
}
