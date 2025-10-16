using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동 / 점프 설정")]
    [SerializeField] private float jumpForce = 5f;  // 점프 높이
    [SerializeField] private float startTime = 2.0f;  // 시작 대기 시간

    private Rigidbody2D rb;
    private bool canJump;
    private bool isStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;  // 시작 전 정지 상태
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(startTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        isStarted = true;
    }

    void Update()
    {
        if (!isStarted) return;

        // 점프 입력 (Space 또는 마우스 클릭 둘 다 허용)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // 점프 전 속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 바닥에 닿으면 비활성화 (예: 게임오버 처리)
            gameObject.SetActive(false);
        }
    }
}
