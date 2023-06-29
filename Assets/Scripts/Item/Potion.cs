using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionsTypes
{
    Health,
    Stamina,
    Mana
}

public class Potion : Item
{
    public string Name;
    public int RestoreValue;
    [SerializeField] private PotionsTypes type;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void GetUsed()
    {
        switch(type)
        {
            case PotionsTypes.Health:
                player.RestoreHealth(RestoreValue);
                break;

            case PotionsTypes.Stamina: 
                break;

            case PotionsTypes.Mana:
                break;
        }
    }
}
