using UnityEngine;
using UnityEngine.Events;

public class TriggerStepper : MonoBehaviour {
    public UnityEvent onStep;
    public float minimumTime = 0.1f;
    public float stepDistance = 1f;
    float distanceTravelled = 0;
    float timeSinceLastStep = 0;

    Vector3 lastPosition;
    void Start()
    {
        lastPosition = transform.position;
    }
    void Update()
    {
        float newDistance = Vector3.Distance(transform.position, lastPosition);
        distanceTravelled += newDistance;
        timeSinceLastStep += Time.deltaTime;
        lastPosition = transform.position;
        if (distanceTravelled > stepDistance && timeSinceLastStep > minimumTime) {
            timeSinceLastStep = 0;
            distanceTravelled = 0;
            onStep.Invoke();
        }
    }
}
