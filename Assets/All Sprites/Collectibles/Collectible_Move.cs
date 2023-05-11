using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Move : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 currentPos;
        currentPos = spriteRenderer.transform.position;
        offset = moveSpeed * Time.deltaTime;
        spriteRenderer.transform.position = currentPos + offset;
    }
}
