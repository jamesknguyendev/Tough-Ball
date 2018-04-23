using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{

	public GameObject spikePrefab;
	private Spike spike;
	private const float UPPER_RANGE = 2f;

	private const float LOWER_RANGE = -2f;

	private float x;
	private float y;

	private GameObject spawnedSpike;
	private float initialSpeed;
	private float increasedSpeed;
	private float MAX_SPEED;
	void Start()
	{
		initialSpeed = 2.0f;
		increasedSpeed = 0.1f;
		MAX_SPEED = 6f;
		x = gameObject.transform.position.x;
		InvokeRepeating("SpawnSpike", 1f, 3f);
	}

	void SpawnSpike()
	{
		y = Random.Range(LOWER_RANGE, UPPER_RANGE);
		spawnedSpike = Instantiate(spikePrefab, new Vector2(x, y), Quaternion.identity);
		spike = spawnedSpike.GetComponent<Spike>();
		if (initialSpeed < MAX_SPEED)
		{
			initialSpeed += increasedSpeed;
			spike.SetSpeed(initialSpeed);
		}
		
		Destroy(spawnedSpike,10f);
	}
}
