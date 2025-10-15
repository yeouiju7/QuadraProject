
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�̵�/����")]
    [SerializeField] private float moveSpeed;  //�����̴� �ӵ�
    [SerializeField] private float JumpForce;  //���� ����

    [SerializeField] private float startTime = 2.0f;  //�����̱� ���� ��� �ð�

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
