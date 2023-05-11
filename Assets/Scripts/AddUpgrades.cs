using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddUpgrades : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject[] buttons;
    public static int[] cost = new int[] { 100, 400 };
    [SerializeField] float[] increase;
    [SerializeField] TextMeshProUGUI[] increment;
    [SerializeField] TextMeshProUGUI[] priceText;


    public static float score = 0f;
    public static float idle = 0f;
    public static float additive = 0f;
    public static float multiplicitive = 1f;


    void Update()
    {
        score += (idle * multiplicitive);
        text.text = "Coins: " + score;
    }

    public void Loading()
    {
        for (int i = 0; i < priceText.Length; i++)
        {
            priceText[i].text = "Coin Value +" + increase[i] + "\nCost: " + (int)cost[i];
            increment[0].text = additive.ToString();
        }
    }

    public void AddUpgrade(int button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        int price = cost[button];
        if (score > price)
        {
            additive += increase[button];
            score -= price;
            float temp = price;
            temp = temp * 1.1f;
            cost[button] = (int)temp;
            priceText[button].text = "Coin Value +" + increase[button] + "\nCost: " + (int)temp;
            increment[0].text = additive.ToString();
        }
    }
}
