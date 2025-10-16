
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [Header("이동")]
    [SerializeField] private float jumpForce;  //점프 높이

    [SerializeField] private float startTime = 2.0f;  //움직이기 시작 대기 시간
=======
    [Header("점프 높이")]
    [SerializeField] private float jumpForce;  //점프 높이
>>>>>>> 0a082b285d2ed24480ecf48344792ef79b6403ad

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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space))
=======
        if (Input.GetMouseButton(0))
>>>>>>> 0a082b285d2ed24480ecf48344792ef79b6403ad
        {
            canJump = true;
        }
        


    }
    private void FixedUpdate()
    {
        if (canJump)
        {
<<<<<<< HEAD
            //rb.velocity = new Vector2(rb.velocity.x, 0);
=======
            rb.velocity = new Vector2(rb.velocity.x, 0);
>>>>>>> 0a082b285d2ed24480ecf48344792ef79b6403ad

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(startTime);

        rb.bodyType = RigidbodyType2D.Dynamic;
=======
        if (collision.gameObject.tag == "Ground")
        {
            transform.gameObject.SetActive(false);
        }
>>>>>>> 0a082b285d2ed24480ecf48344792ef79b6403ad
    }
}
