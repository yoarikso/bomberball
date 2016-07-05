using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] objects;

	public float spawnMinTimeBound = 1f;
	public float spawnMaxTimeBound = 2f;
	public int maxSpawns = 5;

	private int spawnCounter = 0;
	private int score = 0;

	Component[] childrenComponent = null;

	// Use this for initialization
	void Start () {
		spawnCounter = 0;
		score = 0;
		Spawn ();
	}

	void Spawn() {

		// chose which child component to spawn
		childrenComponent = this.gameObject.GetComponentsInChildren<Component> ();
		Component chosenChild = childrenComponent[Random.Range(0, childrenComponent.GetLength(0))];

		// spanw pos
		Vector3 spawnPos = chosenChild.transform.position;

		// pick random object on the list, and instantiate them
		GameObject chosenObject = objects [Random.Range (0, objects.GetLength (0))];

		// instantiate there, son
		if(spawnCounter < maxSpawns)
		{
			GameObject obj = (GameObject)Instantiate(chosenObject, spawnPos, Quaternion.identity);

			// get the script component, so that we can listen to the event
			GoldenBox box = obj.GetComponent<GoldenBox>();
			box.OnDeathRattleEvent += new GoldenBox.DeathRattleHandler(HandleOnDeathRattleEvent);

			spawnCounter++;
		}

		// Spawn again, in some random time
		Invoke("Spawn", Random.Range(spawnMinTimeBound, spawnMaxTimeBound));
	}

	void HandleOnDeathRattleEvent ()
	{
		DecreaseSpawnCounter ();
		IncreaseScore ();
	}

	void DecreaseSpawnCounter()
	{
		if(spawnCounter > 0) 
			spawnCounter--;
	}

	void IncreaseScore()
	{
		score++;
	}

	public int Score
	{
		get { return score; }
	}
}
