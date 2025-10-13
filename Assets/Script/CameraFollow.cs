using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // Player
    public float smoothSpeed = 5f;
    public Vector3 offset;        // Posisi offset kamera terhadap player

    private void LateUpdate()
    {
        if (target == null) return;

        // Posisi target kamera (mengikuti player)
        Vector3 desiredPosition = target.position + offset;

        // Smooth movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Tetapkan posisi kamera
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);

    }
}
