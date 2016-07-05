using UnityEngine;
using System.Collections;

public class TNTExplosion : MonoBehaviour {

	public float force;
	public float radius;

	public GameObject explosion;

	// Update is called once per frame
	void OnMouseDown () 
	{
		// get all the object around the spherical radius
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		
		// explode them out
		foreach(Collider c in colliders)
		{
			if(c.rigidbody == null) continue;
			
			// explosion everywhere
			c.rigidbody.AddExplosionForce(force, transform.position, radius, 0.5f, ForceMode.Impulse);
		}

		Instantiate (explosion, transform.position, Quaternion.identity);

		Destroy (this.gameObject);
	}
}
