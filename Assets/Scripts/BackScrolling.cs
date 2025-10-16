using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrolling : MonoBehaviour
{
    [Header("배경조정")]
    [SerializeField] float speed;
    [SerializeField] int startIndex;
    [SerializeField] int endIndex;

    public Transform sprite;
    private float viewWidth;
    private float spriteWidth;

    private void Start()
    {
        viewWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        spriteWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;        

        if (sprite.position.x < -viewWidth/2 -spriteWidth/2)
        {
            sprite.position = sprite.position + Vector3.right * spriteWidth * 2.8f;            
        }
    }
}
