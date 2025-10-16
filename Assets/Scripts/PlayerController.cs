
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동")]
    [SerializeField] private float jumpForce;  //점프 높이

    [SerializeField] private float startTime = 2.0f;  //움직이기 시작 대기 시간

    private Rigidbody2D rb;

    private bool canJump;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        


    }
    private void FixedUpdate()
    {
        if (canJump)
        {
            //rb.velocity = new Vector2(rb.velocity.x, 0);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        canJump = false;
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startTime);

        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
