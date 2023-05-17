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
        increment[0].text = Static.multiplyAmount.ToString();
    }

    public void MultiplyUpgrade(int button)
    {
        int price = cost[button];
        if (AddUpgrades.score > price)
        {
            Static.multiplyAmount *= increase[button];
            AddUpgrades.score -= price;
            Destroy(buttons[button]);
            increment[button].text = Static.multiplyAmount.ToString();
            deleted[button] = true;
        }
    }
}
