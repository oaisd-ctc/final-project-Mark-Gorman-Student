using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTypeChances : MonoBehaviour
{
    [SerializeField] int[] cost;
    [SerializeField] float[] increase;
    [SerializeField] GameObject[] buttons;
    [SerializeField] int[] coin;
    [SerializeField] public static bool[] deleted = new bool[2];

    private void Awake()
    {
        if (MenuLoading.LoadDataOnStart)
        {
            Loading();
        }
    }
    public void Loading()
    {
        for (int hi = 0; hi <= deleted.Length - 1; hi++)
        {
            if (deleted[hi])
            {
                Destroy(buttons[hi]);
            }
        }
    }

    public void Upgrade(int Number)
    {
        int price = cost[Number];
        if (AddUpgrades.score > price)
        {
            for (int i = 1; i <= coin[Number]; i++)
            {
                CoinSpawner.coinChances[i] -= increase[Number];
            }
            AddUpgrades.score -= price;
            Destroy(buttons[Number]);
            deleted[Number] = true;
        }
    }
}
