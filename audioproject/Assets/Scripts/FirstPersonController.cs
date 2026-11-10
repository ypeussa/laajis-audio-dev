using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstPersonController : MonoBehaviour {
    public float sensitivityX = 1f;
    public float sensitivityY = 1f;
    public bool invertY = false;
    public float speed = 1f;

    public float stepMinInterval = 0.5f;
    float stepTimer = 0f;
    public UnityEvent footstepEvent;

    Transform camera;

    void Start() {
        camera = transform.Find("Camera");
    }

    void Update() {
        stepTimer -= Time.deltaTime;
        var mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivityY * (invertY ? 1 : -1);
        transform.Rotate(0, mouseX, 0);
        camera.Rotate(mouseY, 0, 0);
        var input = Input.GetAxis("Horizontal") * transform.right +
            Input.GetAxis("Vertical") * transform.forward;
        if (input.magnitude > 1)
            input.Normalize();
        if (input.magnitude > 0.1f) {
            if (stepTimer < 0) {
                footstepEvent.Invoke();
                stepTimer = stepMinInterval;
            }
        }
        transform.position += input * Time.deltaTime * speed;
    }
}
