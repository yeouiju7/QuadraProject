using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float speed;
   
    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
