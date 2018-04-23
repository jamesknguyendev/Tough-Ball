using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public GameObject startWindow;
	private ScoreManager scoreManager;
	public AdsManager adsManager;

	public void StartGame()
	{
		scoreManager.ResetPreviousScore();
		Time.timeScale = 1;
		startWindow.SetActive(false);
	}

	public void Restart()
	{	
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		//Time.timeScale = 1;
		
	}
	void Awake()
	{
		Debug.Log("Start Game");
		Time.timeScale = 0;
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		adsManager = GameObject.FindGameObjectWithTag("AdsManager").GetComponent<AdsManager>();

	}
	void Start()
	{
		scoreManager.UpdateRecord();
		adsManager.ShowAds();
	}
	
	
	
}
