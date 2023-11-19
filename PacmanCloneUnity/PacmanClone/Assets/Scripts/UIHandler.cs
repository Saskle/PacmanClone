using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;

    void Update()
    {
        UpdateScore();

        if (GameManager.Instance.gameOver)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Your score was " + GameManager.Instance.currentScore + ".";
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.Instance.currentScore;
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();

        //GameManager.Instance.gameOver = false;
        //SceneManager.LoadScene("Game");
    }
}
