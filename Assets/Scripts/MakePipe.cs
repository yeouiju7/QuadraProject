using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Threading;
>>>>>>> feat/back
using UnityEngine;

public class MakePipe : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject Pipe;
    public float timeDiff;

    float timer = 0;
=======
    public GameObject pipe;            //적용할 오브젝트

    [SerializeField] float timeDiff;   //오브젝트의 리스폰 시간

    [SerializeField] float spawnX;

    [SerializeField] float spawnMaxY;
    [SerializeField] float spawnMinY;

    private float timer = 0;


    private void Awake()
    {
        pipe = GetComponent<GameObject>();
    }
>>>>>>> feat/back

    void Update()
    {
        timer += Time.deltaTime;
<<<<<<< HEAD
        if (timer > timeDiff)
        {
            GameObject newpipe = Instantiate(Pipe); //파이프를 계속 생성하는 식
            newpipe.transform.position = new Vector3(0, Random.Range(2.88f, 6.44f), 0); 
            //파이프 y축 랜덤 생성
            timer = 0;
            Destroy(newpipe, 10.0f); //10초 뒤 파이프 사라짐(이미 지나간 파이프 제거)
        }
        
=======

        if (timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3 (spawnX, Random.Range(spawnMaxY, spawnMinY), 0 );
            timer = 0;
            Destroy(newPipe, 5);
        }
>>>>>>> feat/back
    }
}
