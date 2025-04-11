using UnityEngine;

public class StayInsideTrigger : MonoBehaviour
{
    private Vector3 lastSafePosition;

    void Start()
    {
        lastSafePosition = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WalkableArea"))
        {
            lastSafePosition = transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WalkableArea"))
        {
            Debug.Log("Out of bounds! Returning to last safe position.");
            transform.position = lastSafePosition;
        }
    }
}
