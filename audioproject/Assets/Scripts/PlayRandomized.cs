using UnityEngine;

public class PlayRandomized : MonoBehaviour {
    public AudioSource audio;
    public AudioClip[] clips;

    public void Play() {
        if (clips.Length == 0) {
            Debug.LogWarning("no clips to play from");
            return;
        }

        if (audio == null) {
            Debug.LogWarning("no audio source assigned or on object");
            return;
        }
        audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
    void Awake() {
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
    }
}
