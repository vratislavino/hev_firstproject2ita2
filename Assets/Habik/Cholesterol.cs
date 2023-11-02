using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cholesterol
{
    public event Action<int> CholesterolChanged;
    public event Action<int> Died;

    private int score = 0;
    private int highScore = 0;

    private static Cholesterol instance = new Cholesterol();

    public static Cholesterol Instance => instance;

    private Cholesterol() { }

    public void AddCholesterol(int amount) {

        score += amount;
        CholesterolChanged?.Invoke(score);

        if(score > highScore)
            highScore = score;

        if (score < 0) {
            Time.timeScale = 0;
            Died?.Invoke(highScore);
        } 
    }

    public void RestartCholesterol() {
        highScore = 0;
        score = 0;
    }
}
