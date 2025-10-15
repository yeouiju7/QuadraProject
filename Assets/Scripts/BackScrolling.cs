using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrolling : MonoBehaviour
{
    [Header("설정")]
    public Transform camera;
    [SerializeField] float scrollingSpeed = 0.0f;
    [SerializeField] int spriteCount = 2;

    private Vector2 prevCamPos;
    private float spriteWidth;

    private void Start()
    {
        //카메라가 아니면(없으면) 카메라는 메인카메라로 지정
        if(!camera) camera = Camera.main.transform;

        // 배경 사진을 불러오기위한 함수
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //배경이 있으면 원드단위 사이즈 측정
        if(spriteRenderer != null)
        {
            spriteWidth = spriteRenderer.bounds.size.x;
        }
    }

    private void LateUpdate()
    {
        //카메라 이동량
        Vector2 delta = (Vector2)camera.position - prevCamPos;

        //이동로직
        transform.position += new Vector3(delta.x * scrollingSpeed, 0.0f, 0.0f);

        //이전 카메라 위치 저장
        prevCamPos = camera.position;

        //카메라가 월드 좌표 기준 어디에 있나 - 카메라의 중심에서 오른쪽이나 왼쪽의 거리
        float leftEdge = camera.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        
        //배경 옮기기
        if(transform.position.x + spriteWidth * 0.5f < leftEdge)
        {
            transform.position += Vector3.right * (spriteWidth * spriteCount);
        }
    }
}
