using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TransitionMixerSnapshot : MonoBehaviour
{
    public AudioMixerSnapshot snapshot1, snapshot2, snapshot3;
    public float transitionSeconds;

    public void Transition1() {
        snapshot1.TransitionTo(transitionSeconds);
    }

    public void Transition2()
    {
        snapshot2.TransitionTo(transitionSeconds);
    }

    public void Transition3()
    {
        snapshot3.TransitionTo(transitionSeconds);
    }
}
