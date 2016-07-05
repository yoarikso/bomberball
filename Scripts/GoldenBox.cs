using UnityEngine;
using System.Collections;
using System;

public class GoldenBox : MonoBehaviour {

	public GameObject explosion;
	public event DeathRattleHandler OnDeathRattleEvent; 
	public delegate void DeathRattleHandler();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, 1, 0), Time.deltaTime * 60);
	}

	void OnCollisionEnter(Collision collision)
	{
		// we know that the only one that has rigid body is The Ball
		// kaboom is needed for reference after this.gameObject is dead
		GameObject kaboom = (GameObject)Instantiate (explosion, this.gameObject.transform.position, Quaternion.identity);
		Destroy (kaboom, 5.0f);

		// Fire Event
		if (OnDeathRattleEvent != null)
			OnDeathRattleEvent.Invoke ();

		// poof!
		Destroy (this.gameObject);
	}	
}
