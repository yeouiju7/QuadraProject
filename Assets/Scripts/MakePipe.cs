using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    [Header("������ ���� ����")]
    [SerializeField] private GameObject pipe;      // ������ ������Ʈ
    [SerializeField] private float timeDiff = 1f;  // ���� �ֱ� (��)
    [SerializeField] private float spawnX = 10f;   // ���� ��ġ X��ǥ
    [SerializeField] private float spawnMaxY = 6.44f; // Y �ִ밪
    [SerializeField] private float spawnMinY = 2.88f; // Y �ּҰ�

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
            Destroy(newPipe, 10f); // 10�� �� ����
        }
    }
}
