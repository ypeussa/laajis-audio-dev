using UnityEngine;

public class Popup : MonoBehaviour {
    public string message = "ping";
    public void TimedPopup(float seconds) {
        // TODO: actual graphical popup
        print(message);
    }
}
