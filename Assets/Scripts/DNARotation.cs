using UnityEngine;

public class DNARotation : MonoBehaviour
{
    public float rotationSpeed = 20f;  // Degrees per second

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
