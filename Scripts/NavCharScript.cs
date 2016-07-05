using UnityEngine;
using System.Collections;

public class NavCharScript : MonoBehaviour {
	
	NavMeshAgent agent;
	private ThirdPersonCharacter character;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		character = GetComponent<ThirdPersonCharacter>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// ray cast on left click
		if (Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100))
			{
				// move him
				if(agent) agent.SetDestination(hit.point);

				// please animate?
				if(character) character.OnAnimatorMove();
				//character.Move( agent.desiredVelocity, false, false, hit.point );
				//character.Move ( Vector3.zero, false, false, Vector3.zero );
			}
		}
	}
}
