using UnityEngine;
using System.Collections;

public class EqualPowerCrossfade : MonoBehaviour
{
    public AudioSource sourceA;
    public AudioSource sourceB;

    [Range(0f, 1f)] public float mix = 0f;   // 0 = only A, 1 = only B
    public bool linear = false;
    
    void Update()
    {
        ApplyMix(mix);
    }

    void ApplyMix(float t) {
        if (linear) {
            sourceA.volume = 1 - t;
            sourceB.volume = t;
        } else {
            float angle = t * Mathf.PI * 0.5f;
            sourceA.volume = Mathf.Cos(angle);
            sourceB.volume = Mathf.Sin(angle);
        }
    }

    public IEnumerator Fade(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            mix = Mathf.Clamp01(elapsed / duration);
            ApplyMix(mix);
            yield return null;
        }
        mix = 1f;
        ApplyMix(1f);
    }
}