using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
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

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3 (spawnX, Random.Range(spawnMaxY, spawnMinY), 0 );
            timer = 0;
            Destroy(newPipe, 5);
        }
    }
}
