using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TriggerKeypress : MonoBehaviour {
    //public KeyCode key;
    public UnityEvent reaction;
    [SerializeField] private InputAction keyToRead;

    private void OnEnable()  => keyToRead.Enable();
    private void OnDisable() => keyToRead.Disable();

    private void Update()
    {
        if (keyToRead.WasPressedThisFrame())
            reaction.Invoke();
    }
}
