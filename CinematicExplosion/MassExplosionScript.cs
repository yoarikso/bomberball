using UnityEngine;
using System.Collections;

public class MassExplosionScript : MonoBehaviour {

	public float force;
	public float radius;

	// Use this for initialization
	void Start () {
	
	}

	// unity fixed update?
	
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
			if (Physics.Raycast (ray, out hit, 100)) 
			{
				// get all the object around the spherical radius
				Collider[] colliders = Physics.OverlapSphere(hit.point, radius);

				// explode them out
				foreach(Collider c in colliders)
				{
					if(c.rigidbody == null) continue;

					// forward translation force ala starwars
					//c.rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);

					// explosion everywhere
					c.rigidbody.AddExplosionForce(force, hit.point, radius, 0.5f, ForceMode.Impulse);
				}
			}
		}
	}
}
