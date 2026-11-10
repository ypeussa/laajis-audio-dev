using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SnapshotMixer : MonoBehaviour
{
    public AudioMixerSnapshot snapshot1;
    public AudioMixerSnapshot snapshot2;
    // public Slider slider;
    [Range(0f, 1f)] public float mix;
    public AudioMixer mixer;

    public void UpdateSnapshotMixing() {
        // float snap2 = slider.value;
        // float snap1 = 1 - snap2;
        float snap2 = mix;
        float snap1 = 1 - mix;
        // TODO: if using this for crossfade, should fix decibels!
        mixer.TransitionToSnapshots(
            new AudioMixerSnapshot[] { snapshot1, snapshot2 },
            new float[] { snap1, snap2 },
            0);    
    }
}
