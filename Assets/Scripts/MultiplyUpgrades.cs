using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiplyUpgrades : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] int[] cost;
    [SerializeField] float[] increase;
    [SerializeField] TextMeshProUGUI[] increment;
    [SerializeField] public static bool[] deleted = new bool[2];

    public void Loading()
    {
        for (int hi = 0; hi <= deleted.Length - 1; hi++)
        {
            if (deleted[hi])
            {
                Destroy(buttons[hi]);
            }
        }
        increment[0].text = AddUpgrades.multiplicitive.ToString();
    }

    public void MultiplyUpgrade(int button)
    {
        int price = cost[button];
        if (AddUpgrades.score > price)
        {
            AddUpgrades.multiplicitive *= increase[button];
            AddUpgrades.score -= price;
            Destroy(buttons[button]);
            increment[button].text = AddUpgrades.multiplicitive.ToString();
            deleted[button] = true;
        }
    }
}
