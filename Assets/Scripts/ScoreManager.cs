using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text startWindowScoreText;
    public Text highestScoreText;
    private int score;
    private int highestScore;
    private SoundManager soundManager;
    
    public void AddScoreBy(int amount)
    {
        score += amount;
        if (score > highestScore)
        {
            soundManager.PlayReachedHighScore();
            highestScore = score;
            //UpdateHighestScoreText();
            SaveHighScore();
        }
        SavePreviousScore();
        UpdateScore();
    }

    public void UpdateRecord()
    {
        UpdateScoreRecord();
        UpdateHighestScoreRecord();
    }

    public void ResetPreviousScore()
    {
        score = 0;
        UpdateScore();
        SavePreviousScore();
    }

    public void ShareTwitter()
    {
        ShareUtil.ShareOnTwitter(highestScore);
    }

    public void ShareFacebook()
    {
        ShareUtil.ShareOnFacebook(highestScore);
    }
    
    void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        LoadHighScore();   
        LoadPreviousScore();
        //score = 0;
        UpdateScore();
        

    }

    void Start()
    {
        UpdateScoreRecord();
        UpdateHighestScoreRecord();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    void UpdateScoreRecord()
    {     
        startWindowScoreText.text = "LAST SCORE:\n" + score.ToString();
    }

    void UpdateHighestScoreRecord()
    {
            highestScoreText.text = "HIGH SCORE:\n" + highestScore.ToString();         
    }
//
    void LoadPreviousScore()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        else
        {
            score = 0;
            PlayerPrefs.SetInt("score",score);
        }
    }

    void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("highest_score"))
        {
            highestScore = PlayerPrefs.GetInt("highest_score");
        }
        else
        {
            highestScore = 0;
            PlayerPrefs.SetInt("highest_score",highestScore);
        }
    }
//
    void SavePreviousScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
    
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("highest_score", highestScore);
    }
}
