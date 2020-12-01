using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.Universal;

public class Guard : MonoBehaviour {

    public float speed = 5;
    public float waitTime = 2;
    
    private const string WALKING_UP = "WalkingUP", 
    WALKING_DOWN = "WalkingDOWN", 
    WALKING_LR = "WalkingLR";

    [SerializeField] FieldOfView fov = default;
    [SerializeField] Transform fovPosition = default;
    public Transform pathParent = default;
    /*private Transform player = default;*/
    //public Light2D pointLight;
    public Rigidbody2D rig = default;
    public Animator anim = default;

    void Start() {
        Vector3[] waypoints = new Vector3[pathParent.childCount];
        for (int i = 0; i < waypoints.Length; i++) {
            waypoints[i] = pathParent.GetChild(i).position;
        }

        StartCoroutine(FollowPath(waypoints));
    }

    void Update() {
        HandleFov();
        HandleAnimation();
    }

    IEnumerator FollowPath(Vector3[] waypoints) {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while (true) {
            rig.velocity = (targetWaypoint - transform.position).normalized * speed;
            float distance = Vector3.Distance(targetWaypoint, transform.position);
            TurnToFace(rig.velocity);

            if (distance < 0.3f) {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                rig.velocity = Vector3.zero;
                yield return new WaitForSeconds(waitTime);
            }

            yield return null;
        }
        
    }

    void TurnToFace(Vector2 velocity) {
        if (velocity.x > 0) transform.eulerAngles = new Vector3(0f, 0f, 0f);
        if (velocity.x < 0) transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    void OnDrawGizmos() {
        Vector3 startPosition = pathParent.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathParent) {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }

    void HandleFov() {
        fov.SetOrigin(fovPosition.position);
    }
    
    void HandleAnimation() {
            // UP & DOWN MOVEMENT
            if (rig.velocity.y > 0 && Mathf.Abs(rig.velocity.y) > Mathf.Abs(rig.velocity.x) * 1.3) 
            {
                anim.SetBool(WALKING_UP, true);
                anim.SetBool(WALKING_LR, false);
            }

            if (rig.velocity.y < 0 && Mathf.Abs(rig.velocity.y) > Mathf.Abs(rig.velocity.x) * 1.3) 
            {
                anim.SetBool(WALKING_DOWN, true);
                anim.SetBool(WALKING_LR, false);
            }

            if (rig.velocity.y == 0) 
            {
                if (anim.GetBool(WALKING_UP))
                    anim.SetBool(WALKING_UP, false);
                
                if (anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_DOWN, false);
            }

            // LEFT & RIGHT MOVEMENT
            if (rig.velocity.x > 0 || rig.velocity.x < 0) 
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN)) {
                    anim.SetBool(WALKING_LR, true);
                }
            }

            if (rig.velocity.x == 0)
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_LR, false);
            }
    }

}

#region backup
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public float speed = 5;
    public float waitTime = 0.5f;

    public Transform pathParent;

    void Start() {
        Vector3[] waypoints = new Vector3[pathParent.childCount];
        for (int i = 0; i < waypoints.Length; i++) {
            waypoints[i] = pathParent.GetChild(i).position;
        }

        StartCoroutine(FollowPath(waypoints));
    }

    IEnumerator FollowPath(Vector3[] waypoints) {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while (true) {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint) {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length; // (0 + 1) % 5
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
        
    }

    void OnDrawGizmos() {
        Vector3 startPosition = pathParent.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathParent) {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }

    void Update() {

    }

}
*/
#endregion