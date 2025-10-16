
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("점프 높이")]
    [SerializeField] private float jumpForce;  //점프 높이

    private Rigidbody2D rb;

    private bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
      
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            canJump = true;
        }
        


    }
    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.gameObject.SetActive(false);
        }
    }
}
