using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playBotton;
    public GameObject gameOver;
    public GameObject sign;
    private int score;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);  
        playBotton.SetActive(false);
        sign.SetActive(false);  

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();  

        for(int i = 0; i < pipes.Length; i++) 
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause() 
    {
        Time.timeScale = 0f;
        player.enabled = false; 
    }   
    public void GameOver()
    {
        gameOver.SetActive(true);
        playBotton.SetActive(true); 
        sign.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


}
