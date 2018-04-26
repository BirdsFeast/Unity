using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour {

	public float speed = 10f;

	private Transform target;

    //AI for pathfinding and navigation.
    UnityEngine.AI.NavMeshAgent agent;

    /// <summary>
    /// initiliazes the agent with a initial destination. 
    /// </summary>
    void Start() {
		target = WaveAPath.points [0];
    
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = target.position;
		agent.speed = speed;
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
            agent.destination = hit.point;
        }
    }
    
	void Update () {
        if (Input.GetMouseButton(1))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            ClickPosition(clickRay);
        }
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("WormObjectiveCollider")) {
			Destroy (gameObject);
			ScoreKeeper.wormsScore++;
		}
	}
}
