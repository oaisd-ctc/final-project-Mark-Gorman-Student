using CI.QuickSave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CallSaveLoad : MonoBehaviour
{
    void Awake()
    {
        if (MenuLoading.LoadDataOnStart)
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {

        EventSystem.current.SetSelectedGameObject(null);
        byte[] tempTimes = new byte[MultiplyUpgrades.deleted.Length];
        byte[] tempChance = new byte[CoinTypeChances.deleted.Length];


        string tempPrice = string.Join(" ", AddUpgrades.cost);


        for (int i = 0; i < MultiplyUpgrades.deleted.Length; i++)
        {
            tempTimes[i] = Convert.ToByte(MultiplyUpgrades.deleted[i]);
        }
        for (int i = 0; i < CoinTypeChances.deleted.Length; i++)
        {
            tempChance[i] = Convert.ToByte(CoinTypeChances.deleted[i]);
        }


        QuickSaveRaw.SaveBytes("DeletedTimes.txt", tempTimes);
        QuickSaveRaw.SaveBytes("DeletedChance.txt", tempChance);

        QuickSaveRaw.SaveString("AddCost.txt", tempPrice);


        QuickSaveWriter.Create("SaveThings")
                       .Write("Score", AddUpgrades.score)
                       .Write("CoinPlus", Static.addAmount)
                       .Write("CoinTimes", Static.multiplyAmount)

                       .Commit();
    }

    public void Load()
    {

        EventSystem.current.SetSelectedGameObject(null);
        QuickSaveReader.Create("SaveThings")
                       .Read<float>("Score", (r) => { AddUpgrades.score = r; })
                       .Read<float>("CoinPlus", (r) => { Static.addAmount = r; })
                       .Read<float>("CoinTimes", (r) => { Static.multiplyAmount = r; })
                       ;


        byte[] tempTimes = QuickSaveRaw.LoadBytes("DeletedTimes.txt");
        byte[] tempChance = QuickSaveRaw.LoadBytes("DeletedChance.txt");

        string[] tempPrice = QuickSaveRaw.LoadString("AddCost.txt").Split(" ");

        for (int i = 0; i < tempPrice.Length; i++)
        {
            AddUpgrades.cost[i] = Convert.ToInt32(tempPrice[i]);
        }

        for (int i = 0; i < tempTimes.Length; i++)
        {
            MultiplyUpgrades.deleted[i] = Convert.ToBoolean(tempTimes[i]);
        }
        for (int i = 0; i < tempChance.Length; i++)
        {
            CoinTypeChances.deleted[i] = Convert.ToBoolean(tempChance[i]);
        }
    }
}
