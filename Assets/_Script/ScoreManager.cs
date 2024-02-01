using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Bird playerBird;
    public Text scoreGameText;
    public Text hightScoreText;

    public int scoreGame = 0;
    public int hightScore = 0;

    private void Start()
    {
        LoadHightScore();
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreGameText.text = playerBird.scoreText.text;
        scoreGame = playerBird.score;
        
        if (scoreGame > hightScore)
        {
            Debug.Log("vao duoc ham if");
            hightScore = scoreGame;
            SaveHightScore();
        }
        hightScoreText.text = hightScore. ToString();
    }

    //luu diem so cao nhat vao playerPrefs
    public void SaveHightScore()
    {
        PlayerPrefs.SetInt("HightScore", hightScore);
        PlayerPrefs.Save();
    }

    //lay diem so cao nhat trong playerPrefs
    public void LoadHightScore()
    {
        hightScore = PlayerPrefs.GetInt("HightScore", 0);
    }
}
