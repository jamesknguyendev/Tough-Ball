using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	private float speed;

	public void SetSpeed(float speed)
	{
		this.speed = speed;
	}
	public void IncreaseSpeedBy(float amount)
	{
		speed += amount;
	}

	public float GetSpeed()
	{
		return speed;
	}

	void Awake()
	{
		speed = 2f;
	}
	void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

}
