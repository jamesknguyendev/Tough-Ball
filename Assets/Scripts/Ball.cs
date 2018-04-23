using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private ScoreManager scoreManager;
	private GameManager gameManager;
	private CamScript cam;
	private BackgroundColor backgroundColor;
	private SoundManager soundManager;
	
	void Awake()
	{
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamScript>();
		backgroundColor = GameObject.FindGameObjectWithTag("BackgroundColor").GetComponent<BackgroundColor>();
		soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Star"))
		{
			soundManager.PlayReward();
			scoreManager.AddScoreBy(1);
			Destroy(other.gameObject);
			backgroundColor.MixRandomColor();
			cam.SetBackgroundColor( backgroundColor.GetCurrentColor());
			
		}
		else if (other.gameObject.CompareTag("Obstacle") )
		{
			//GAME OVER HERE 
			gameManager.Restart();
			//Debug.Log("Game Over");
		}
	}
}
