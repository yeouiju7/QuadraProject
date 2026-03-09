using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeCode : MonoBehaviour
{

    public GameObject Pipe;
    public float timeDiff;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeDiff)
        {
            GameObject newpipe = Instantiate(Pipe); //파이프를 계속 생성하는 식
            newpipe.transform.position = new Vector3(4.0f, Random.Range(3.68f, 6.58f), 0);
            //파이프 y축 랜덤 생성
            timer = 0;
            Destroy(newpipe, 10.0f); //10초 뒤 파이프 사라짐(이미 지나간 파이프 제거)
        }
    }
}
