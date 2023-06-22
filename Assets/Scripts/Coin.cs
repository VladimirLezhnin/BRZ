using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Coins
{
    Copper = 1,
    Silver = 10,
    Gold = 100,
    Platinum = 500,
    Diamond = 1000
}

public class CoinPrefab
{
    public static Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>()
    {
        ["Copper"] = Resources.Load(@"Prefabs\Coins\CopperCoin") as GameObject,
        ["Silver"] = Resources.Load(@"Prefabs\Coins\SilverCoin") as GameObject,
        ["Gold"] = Resources.Load(@"Prefabs\Coins\GoldCoin") as GameObject,
        ["Platinum"] = Resources.Load(@"Prefabs\Coins\PlatinumCoin") as GameObject,
        ["Diamond"] = Resources.Load(@"Prefabs\Coins\DiamondCoin") as GameObject,
    };

    public static List<GameObject> GetCoins(int price)
    {
        var coinsToDrop = new List<GameObject>();

        var coinsArr = Enum.GetValues(typeof(Coins));
        Array.Reverse(coinsArr);
        foreach(var coin in coinsArr)
        {
            var count = price / (int)coin;
            for(int i = 0; i < count; i++)
                coinsToDrop.Add(Prefabs[coin.ToString()]);
            price = price % (int)coin;
        }
        return coinsToDrop;
    }
}

public class Coin : MonoBehaviour
{
    [SerializeField] private int cost;

    /// <summary>
    /// 
    /// </summary>
    /// <returns>ценность монеты</returns>
    public int GetCollected()
    {
        Destroy(gameObject);
        return cost;
    }
}