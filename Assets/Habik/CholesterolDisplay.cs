using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CholesterolDisplay : MonoBehaviour
{
    TMPro.TMP_Text cholesterolText;

    [SerializeField]
    TMPro.TMP_Text highscoreText;

    [SerializeField]
    GameObject deadPanel;

    void Start()
    {
        cholesterolText = GetComponent<TMPro.TMP_Text>();
        Cholesterol.Instance.CholesterolChanged += OnScoreChanged;
        Cholesterol.Instance.Died += OnDied;
    }

    private void OnDied(int highscore) {
        highscoreText.text = highscore.ToString();
        deadPanel.SetActive(true);
    }

    private void OnScoreChanged(int score) {
        cholesterolText.text = score.ToString();
    }

    public void RestartGame() {
        Cholesterol.Instance.CholesterolChanged -= OnScoreChanged;
        Cholesterol.Instance.Died -= OnDied;
        Cholesterol.Instance.RestartCholesterol();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
