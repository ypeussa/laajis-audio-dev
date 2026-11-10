using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerKeypress : MonoBehaviour {
    public KeyCode key;
    public UnityEvent reaction;

    void Update() {
        if (Input.GetKeyDown(key)) {
            reaction.Invoke();
        }

    }
}
