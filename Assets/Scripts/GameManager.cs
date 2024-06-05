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

    public AudioSource audioSource;
    public AudioClip gameOverClip;
    public AudioClip getScoreClip;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        audioSource.clip = getScoreClip;
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        audioSource.Stop();
        audioSource.clip = getScoreClip;

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
        audioSource.clip = gameOverClip;
        audioSource.Play();
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        audioSource.time = 0.5f;
        audioSource.Play();
    }
}
