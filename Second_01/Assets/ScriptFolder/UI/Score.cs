using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int Myscore = 0;
    Text Mytext;

    void Start()
    {
        Mytext = GetComponent<Text>();
    }

    void Update()
    {
        Mytext.text = "Score : " + Myscore;
    }
}
