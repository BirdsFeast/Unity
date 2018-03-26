using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAMovement : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int waypointsIndex = 0;

    //AI for pathfinding and navigation.
    UnityEngine.AI.NavMeshAgent agent;

    /// <summary>
    /// initiliazes the agent with a initial destination. 
    /// </summary>
    void Start() {
		target = WaveAPath.points [0];

        //this controls the movement.
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = target.position;
    }
    /// <summary>
    /// Ray cast collision detection and change of destination.
    /// </summary>
    /// <param name="Click"></param>
    void ClickPosition(Ray Click)
    {
        RaycastHit hit;
        if (Physics.Raycast(Click, out hit))
        {
            Debug.Log("Hit position: " + hit.transform.position);
            agent.destination = hit.point;
        }
    }
    
	void Update () {
        //Get mouse click and casts ray.
        if (Input.GetMouseButton(1))
        {
            Debug.Log("right click");
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            ClickPosition(clickRay);
        }

		/*if (Vector3.Distance (transform.position, target.position) < 0.4f) {
			GetNextWaypoint ();
		}*/
	}
    //not being used now.
	void GetNextWaypoint() {
		waypointsIndex++;
		if (waypointsIndex >= WaveAPath.points.Length) {
			Destroy (gameObject);
			return;
		}
		target = WaveAPath.points [waypointsIndex];
	}
}
