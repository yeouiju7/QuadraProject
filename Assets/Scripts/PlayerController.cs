using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("�̵� / ���� ����")]
    [SerializeField] private float jumpForce = 5f;  // ���� ����

    private Rigidbody2D rb;
    private bool canJump;
    private bool isStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;  // ���� �� ���� ����
    }

    private IEnumerator Start()
    {
        yield return null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        isStarted = true;
    }

    void Update()
    {
        if (!isStarted) return;

        // ���� �Է� (Space �Ǵ� ���콺 Ŭ�� �� �� ���)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // ���� �� �ӵ� �ʱ�ȭ
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �ٴڿ� ������ ��Ȱ��ȭ (��: ���ӿ��� ó��)
            SceneManager.LoadScene("GameOverScene");
        }

        if (Score.score > Score.bestScore)
        {
            Score.bestScore = Score.score;
        }
        

    }

}