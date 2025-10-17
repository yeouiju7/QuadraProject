using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
 
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Best Score : " + Score.bestScore;
    }

}
