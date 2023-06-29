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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if (GameManager.Instance.gameOver)
        {
            gameOverPanel.SetActive(true);
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
