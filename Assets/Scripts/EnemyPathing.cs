using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    List<Transform> waypoints;

    // Use this for initialization
    void Start () {
        
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Move();
    }

    public void SetWaypoints(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
    }
}
