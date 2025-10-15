
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동/점프")]
    [SerializeField] private float moveSpeed;  //움직이는 속도
    [SerializeField] private float JumpForce;  //점프 높이

    [SerializeField] private float startTime = 2.0f;  //움직이기 시작 대기 시간

    private Rigidbody2D rb;

    private bool canMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(StartMoving());
    }
    void Update()
    {
        if (canMove)
        {
            rb.velocity = Vector2.right * moveSpeed;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startTime);

        canMove = true;
    }
}
