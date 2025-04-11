using UnityEngine;
using UnityEngine.XR;

public class WalkSound : MonoBehaviour
{
    public float movementThreshold = 0.01f;
    private AudioSource walkAudio;
    private Vector3 lastPosition;

    void Start()
    {
        walkAudio = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        float movement = (transform.position - lastPosition).magnitude;

        if (movement > movementThreshold)
        {
            if (!walkAudio.isPlaying)
                walkAudio.Play();
        }
        else
        {
            if (walkAudio.isPlaying)
                walkAudio.Pause();
        }

        lastPosition = transform.position;
    }
}
