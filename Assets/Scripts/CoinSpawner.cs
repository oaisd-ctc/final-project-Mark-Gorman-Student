using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] GameObject[] prefab;
    [SerializeField] Vector2[] positionSet1;
    [SerializeField] Vector2[] positionSet2;
    [SerializeField] Vector2[] positionSet3;
    [SerializeField] Vector2[] positionSet4;

    [Header("Maybe Used")]
    Vector2[] SpawnSet;

    int length;

    [Header("Set Spawn Chances")]
    [SerializeField] float Set1 = 0f;
    [SerializeField] float Set2 = 0.7f;
    [SerializeField] float Set3 = 0.9f;
    [SerializeField] float Set4 = 0.95f;

    public static float[] coinChances = new float[8];

    int prefabNum;

    int rand_wait;


    float rando;

    void Awake()
    {
        coinChances[0] = 0f;
        coinChances[1] = 0.8f;
        coinChances[2] = 0.95f;
        coinChances[3] = 1f;
        coinChances[4] = 1f;
        coinChances[5] = 1f;
        coinChances[6] = 1f;
        coinChances[7] = 1f;
        StartCoroutine(SpawnCoins());
    }
    IEnumerator SpawnCoins()
    {
        while (true)
        {
            rand_wait = Random.Range(3, 8);

            rando = Random.value;
            if (rando > Set4)
            {
                SpawnSet = positionSet4;
            }
            else if (rando > Set3)
            {
                SpawnSet = positionSet3;
            }
            else if (rando > Set2)
            {
                SpawnSet = positionSet2;
            }
            else if (rando > Set1)
            {
                SpawnSet = positionSet1;
            }

            length = SpawnSet.Length - 1;

            for (int i = 0; i <= length; i++)
            {
                float rando = Random.value;
                if (rando > coinChances[7])
                {
                    prefabNum = 7;
                }
                else if (rando > coinChances[6])
                {
                    prefabNum = 6;
                }
                else if (rando > coinChances[5])
                {
                    prefabNum = 5;
                }
                else if (rando > coinChances[4])
                {
                    prefabNum = 4;
                }
                else if (rando > coinChances[3])
                {
                    prefabNum = 3;
                }
                else if (rando > coinChances[2])
                {
                    prefabNum = 2;
                }
                else if (rando > coinChances[1])
                {
                    prefabNum = 1;
                }
                else if (rando > coinChances[0])
                {
                    prefabNum = 0;
                }

                var newCollectible = Instantiate(prefab[prefabNum], SpawnSet[i], Quaternion.identity);
                newCollectible.transform.parent = gameObject.transform;
            }
            yield return new WaitForSecondsRealtime(5);
        }
    }
}
