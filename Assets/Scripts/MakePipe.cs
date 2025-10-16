using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    [Header("파이프 스폰 설정")]
    [SerializeField] private GameObject pipe;      // 생성할 오브젝트
    [SerializeField] private float timeDiff = 1f;  // 생성 주기 (초)
    [SerializeField] private float spawnX = 10f;   // 생성 위치 X좌표
    [SerializeField] private float spawnMaxY = 6.44f; // Y 최대값
    [SerializeField] private float spawnMinY = 2.88f; // Y 최소값

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(
                spawnX,
                Random.Range(spawnMinY, spawnMaxY),
                0
            );

            timer = 0;
            Destroy(newPipe, 10f); // 10초 후 삭제
        }
    }
}
