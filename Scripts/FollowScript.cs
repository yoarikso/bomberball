using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {

	NavMeshAgent agent;
	public Transform target;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		agent.SetDestination (target.position);
	}
}
