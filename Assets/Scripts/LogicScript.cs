using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverText;
    public AudioSource gameOverSound;
    public AudioSource gameMusic;

    [ContextMenu("Increase score")]

    private void Start()
    {
        gameOverSound = GetComponent<AudioSource>();
    }
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverText.SetActive(false);
        gameOverSound.Stop();
        gameMusic.GetComponent<AudioSource>().Play();
    }

    public void gameOver(bool alive)
    {
        if (alive)
        {
            gameOverText.SetActive(true);
            gameOverSound.Play();
            gameMusic.GetComponent<AudioSource>().Stop();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
