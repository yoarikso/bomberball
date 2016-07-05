using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float force;
	public float explosionRadius;
	public float upwardModifier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// left click
		if(Input.GetMouseButtonDown(0))
		{
			// cast a ray from mouse pos
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			
			// when hit within 100 distance of the cast ray
			// apply explosion at the hit collider, generate an explosion there
			if (Physics.Raycast (ray, out hit, 100)) {
				rigidbody.AddExplosionForce(force, hit.point, explosionRadius, upwardModifier, ForceMode.Impulse);
			}
		}
	
	}
}
