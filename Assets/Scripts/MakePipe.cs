using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public GameObject Pipe;
    public float timeDiff;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            GameObject newpipe = Instantiate(Pipe); //�������� ��� �����ϴ� ��
            newpipe.transform.position = new Vector3(0, Random.Range(2.88f, 6.44f), 0); 
            //������ y�� ���� ����
            timer = 0;
            Destroy(newpipe, 10.0f); //10�� �� ������ �����(�̹� ������ ������ ����)
        }
        
    }
}
