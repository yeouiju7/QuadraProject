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
    public GameObject pipe;            //������ ������Ʈ

    [SerializeField] float timeDiff;   //������Ʈ�� ������ �ð�

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
            GameObject newpipe = Instantiate(Pipe); //�������� ��� �����ϴ� ��
            newpipe.transform.position = new Vector3(0, Random.Range(2.88f, 6.44f), 0); 
            //������ y�� ���� ����
            timer = 0;
            Destroy(newpipe, 10.0f); //10�� �� ������ �����(�̹� ������ ������ ����)
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
