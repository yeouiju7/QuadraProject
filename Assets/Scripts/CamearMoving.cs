using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamearMoving : MonoBehaviour
{
    [Header("플레이어")]
    public Transform player;

    [SerializeField] private Vector2 offSet = new Vector2(0.0f, 1.0f);
    [SerializeField] private float followSpeed = 5.0f;
    private bool followX = true;
    private bool followY = false;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        if(player)
        {
            Vector3 startPos = player.position;
            startPos.y = player.position.y + offSet.y;
            transform.position = startPos;
        }
    }

    private void LateUpdate()
    {
        if (!player) return;

        Vector3 playerPos = transform.position;

        if(followX)
        {
            playerPos.x = player.position.x + offSet.x;
        }
        if (followY)
        {
            playerPos.y = player.position.y + offSet.y;
        }

        transform.position = Vector3.Lerp(transform.position, playerPos, followSpeed * Time.deltaTime);
    }
}
