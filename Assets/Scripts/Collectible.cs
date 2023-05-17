using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    [SerializeField] int value;
    AudioSource hi;

    void OnTriggerEnter2D(Collider2D collision)
    {
        hi = FindObjectOfType<AudioSource>();
        hi.Play();
        gameObject.SetActive(false);
        Destroy(gameObject);
        AddUpgrades.score += ((value + Static.addAmount) * Static.multiplyAmount);
    }
    void Update()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
