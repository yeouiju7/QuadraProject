using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [Header("이동")]
    [SerializeField] private float jumpForce;  //점프 높이
=======
    [Header("이동 / 점프 설정")]
    [SerializeField] private float jumpForce = 5f;  // 점프 높이
>>>>>>> feat/obs

    private Rigidbody2D rb;
    private bool canJump;
    private bool isStarted = false;

    public Audio audio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;  // 시작 전 정지 상태
    }

    private IEnumerator Start()
    {
        yield return null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        isStarted = true;
    }

    void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButton(0))
=======
        if (!isStarted) return;

        // 점프 입력 (Space 또는 마우스 클릭 둘 다 허용)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
>>>>>>> feat/obs
        {
            audio.PlaySfx(Audio.sfx.JumpSound);
            canJump = true;            
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
<<<<<<< HEAD
            rb.velocity = new Vector2(rb.velocity.x, 0);

=======
            
            rb.velocity = new Vector2(rb.velocity.x, 0); // 점프 전 속도 초기화
>>>>>>> feat/obs
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.tag == "Ground")
        {
            transform.gameObject.SetActive(false);
        }

=======
        if (collision.gameObject.CompareTag("Ground"))
        {  
            // 바닥에 닿으면 비활성화 (예: 게임오버 처리)
            SceneManager.LoadScene("GameOverScene");
        }

        if (Score.score > Score.bestScore)
        {
            Score.bestScore = Score.score;
        }
>>>>>>> feat/obs
    }

}