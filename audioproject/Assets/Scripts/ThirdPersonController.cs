using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonController : MonoBehaviour {
    public Transform camTransform;
    public float speed = 1f;
    float run = 1f;
    public float stepMinInterval = 0.5f;
    float stepTimer = 0f;
    public UnityEvent footstepEvent;

    void Update() {
        var camRight = Vector3.ProjectOnPlane(camTransform.TransformDirection(Vector3.right), Vector3.up).normalized;
        var camForward = Vector3.ProjectOnPlane(camTransform.TransformDirection(Vector3.forward), Vector3.up).normalized;
        stepTimer -= Time.deltaTime;
        var input = Input.GetAxis("Horizontal") * camRight +
            Input.GetAxis("Vertical") * camForward;
        if (input.magnitude > 0.1f) {
            transform.rotation = Quaternion.LookRotation(input);

            if (stepTimer < 0) {
                footstepEvent.Invoke();
                stepTimer = stepMinInterval / run;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = 1;
        }

        var velocity = input * speed * run;
        transform.position += velocity * Time.deltaTime;

    }
}
