using UnityEngine;

public class Guard : MonoBehaviour {
    public Transform[] waypoints;
    public float patrolSpeed = 2f;
    public float threshold = 0.5f;
    public float angleThreshold = 5f;
    public float turningSpeed = 90f;

    int nextWaypoint = 0;
    void Update() {
        var dir = waypoints[nextWaypoint].position - transform.position;        
        var distance = dir.magnitude;
        dir.Normalize();

        var angle = Vector3.Angle(dir, transform.forward);
        var rotationTowardsTarget = Quaternion.LookRotation(dir);
        if (angle < angleThreshold) {
            transform.rotation = rotationTowardsTarget;
            transform.position += dir * patrolSpeed * Time.deltaTime;
        } else {
            var rot = Quaternion.RotateTowards(transform.rotation,
                                                rotationTowardsTarget,
                                                turningSpeed * Time.deltaTime);
            transform.rotation = rot;
        }
        if (distance < threshold) {
            nextWaypoint++;
            if (nextWaypoint >= waypoints.Length) {
                nextWaypoint = 0;
            }
        }
    }
}
