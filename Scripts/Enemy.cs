using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//# hack
	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		// if it's a collision with the Ball
		if (collision.collider.gameObject.name.Contains ("Ball")) 
		{
			// game is over son,
			// TODO: ball can explode if you want

			MenuUICanvas canvas = camera.GetComponent<MenuUICanvas>();
			canvas.TogglePause();

			// activate retry button
			//Debug.Break();
		}
	}
}
