using UnityEngine;

public class CylinderTeleport : MonoBehaviour
{
    public Transform teleportPointA;
    public Transform teleportPointB;
    public GameObject door;
    public float doorOpenZ = 0f;
    public float doorClosedZ = -90f;
    public float doorRotateSpeed = 2f;

    public AudioClip openSound;
    public AudioClip closeSound;

    private AudioSource audioSource;
    private string lastPad = "";
    private bool isTeleporting = false;

    void Start()
    {
        audioSource = door.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = door.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTeleporting) return;

        if (other.gameObject.name == "CylinderA" && lastPad != "CylinderA")
        {
            StartCoroutine(DoorTeleportSequence(teleportPointB.position, "CylinderA"));
        }
        else if (other.gameObject.name == "CylinderB" && lastPad != "CylinderB")
        {
            StartCoroutine(DoorTeleportSequence(teleportPointA.position, "CylinderB"));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CylinderA" || other.gameObject.name == "CylinderB")
        {
            lastPad = "";
        }
    }

    System.Collections.IEnumerator DoorTeleportSequence(Vector3 targetPos, string currentPad)
    {
        isTeleporting = true;

        // Play open sound
        if (openSound != null) audioSource.PlayOneShot(openSound);

        // Open door (rotate Z from -90 to 0)
        yield return StartCoroutine(RotateDoor(doorClosedZ, doorOpenZ));

        yield return new WaitForSeconds(0.3f);

        // Teleport player
        transform.position = targetPos;
        lastPad = currentPad;

        yield return new WaitForSeconds(0.3f);

        // Play close sound
        if (closeSound != null) audioSource.PlayOneShot(closeSound);

        // Close door again (rotate Z from 0 to -90)
        yield return StartCoroutine(RotateDoor(doorOpenZ, doorClosedZ));

        isTeleporting = false;
    }

    System.Collections.IEnumerator RotateDoor(float fromZ, float toZ)
    {
        float elapsed = 0f;
        Vector3 currentRot = door.transform.localEulerAngles;
        Vector3 fromRot = new Vector3(currentRot.x, currentRot.y, fromZ);
        Vector3 toRot = new Vector3(currentRot.x, currentRot.y, toZ);

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * doorRotateSpeed;
            door.transform.localEulerAngles = Vector3.Lerp(fromRot, toRot, elapsed);
            yield return null;
        }

        door.transform.localEulerAngles = toRot;
    }
}
