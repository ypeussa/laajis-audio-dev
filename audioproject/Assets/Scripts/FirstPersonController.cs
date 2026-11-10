using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour {
    public float sensitivityX = 1f;
    public float sensitivityY = 1f;
    public bool invertY = false;
    public float speed = 1f;

    public float stepMinInterval = 0.5f;
    float stepTimer = 0f;
    public UnityEvent footstepEvent;

    Rigidbody rb;
    Transform camera;

    void Awake() {
        camera = transform.Find("Camera");
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        stepTimer -= Time.deltaTime;
        var mouseX = Mouse.current.delta.ReadValue().x * sensitivityX;
        var mouseY = Mouse.current.delta.ReadValue().y * sensitivityY * (invertY ? 1 : -1);
        transform.Rotate(0, mouseX, 0);
        camera.Rotate(mouseY, 0, 0);
        float horizInput = ((Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) ? -1 : 0) +
                           ((Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) ? 1 : 0);
        horizInput = Mathf.Clamp(horizInput, -1, 1);
        float vertInput = ((Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) ? 1 : 0) +
                          ((Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) ? -1 : 0);
        vertInput = Mathf.Clamp(vertInput, -1, 1);
        var input = horizInput * transform.right + 
                        vertInput * transform.forward;
        if (input.magnitude > 1)
            input.Normalize();
        if (input.magnitude > 0.1f) {
            if (stepTimer < 0) {
                footstepEvent.Invoke();
                stepTimer = stepMinInterval;
            }
        }
        rb.MovePosition(rb.position + input * Time.deltaTime * speed);
    }
}
