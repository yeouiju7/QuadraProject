using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�̵� / ���� ����")]
    [SerializeField] private float jumpForce = 5f;  // ���� ����
    [SerializeField] private float startTime = 2.0f;  // ���� ��� �ð�

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
        yield return new WaitForSeconds(startTime);
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
            gameObject.SetActive(false);
        }
    }
}
