using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arik_Script : MonoBehaviour
{
    //Make a list of waypoints
    public List<GameObject> Waypoints;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;
    private int currentWaypoint;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Measure distance between points
        if (Vector3.Distance(transform.position, Waypoints[currentWaypoint].transform.position) < 1.0f)
        {
            // We are within range of current waypoint, so we set the next waypoint as the active one
            currentWaypoint++;

            if (currentWaypoint >= Waypoints.Count)
            {
                // reset to first waypoint, if there are no more waypoints in list.
                currentWaypoint = 0; 
            }
            
            Debug.Log($"Now moving towards waypoint {currentWaypoint}");
        }
        else
        {
            // Move to waypoint
            navMeshAgent.SetDestination(Waypoints[currentWaypoint].transform.position);
        }

        if (navMeshAgent.isStopped == true)
        {
            animator.SetFloat("Speed", 0.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.7f);
        }
        
    }
}
