using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrolling : MonoBehaviour
{
    [Header("����")]
    public Transform camera;
    [SerializeField] float scrollingSpeed = 0.0f;
    [SerializeField] int spriteCount = 2;

    private Vector2 prevCamPos;
    private float spriteWidth;

    private void Start()
    {
        //ī�޶� �ƴϸ�(������) ī�޶�� ����ī�޶�� ����
        if(!camera) camera = Camera.main.transform;

        // ��� ������ �ҷ��������� �Լ�
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //����� ������ ������� ������ ����
        if(spriteRenderer != null)
        {
            spriteWidth = spriteRenderer.bounds.size.x;
        }
    }

    private void LateUpdate()
    {
        //ī�޶� �̵���
        Vector2 delta = (Vector2)camera.position - prevCamPos;

        //�̵�����
        transform.position += new Vector3(delta.x * scrollingSpeed, 0.0f, 0.0f);

        //���� ī�޶� ��ġ ����
        prevCamPos = camera.position;

        //ī�޶� ���� ��ǥ ���� ��� �ֳ� - ī�޶��� �߽ɿ��� �������̳� ������ �Ÿ�
        float leftEdge = camera.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        
        //��� �ű��
        if(transform.position.x + spriteWidth * 0.5f < leftEdge)
        {
            transform.position += Vector3.right * (spriteWidth * spriteCount);
        }
    }
}
