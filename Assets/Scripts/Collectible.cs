using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    [SerializeField] int value;

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        AddUpgrades.score += ((value + AddUpgrades.additive) * AddUpgrades.multiplicitive);
    }
    void Update()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
