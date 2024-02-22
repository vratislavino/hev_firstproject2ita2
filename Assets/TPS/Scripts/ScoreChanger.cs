using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChanger : MonoBehaviour
{
    TMP_Text scoreText;
    int score = 0;  

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
