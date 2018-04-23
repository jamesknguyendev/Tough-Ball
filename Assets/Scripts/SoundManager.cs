using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioClip jumpSound;
	public AudioClip rewardSound;
	public AudioClip reachHighScoreSound;

	private AudioSource source;

	public void PlayJump()
	{
		source.PlayOneShot(jumpSound);
	}

	public void PlayReward()
	{
		source.PlayOneShot(rewardSound);
	}

	public void PlayReachedHighScore()
	{
		source.PlayOneShot(reachHighScoreSound);
	}
	
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	
	
}
