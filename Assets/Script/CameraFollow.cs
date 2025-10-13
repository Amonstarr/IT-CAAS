using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      
    public float smoothSpeed = 5f;
    public Vector3 offset;

    [Header("Camera Bounds")]
    public bool useBounds = true;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Kalau pakai batas
        if (useBounds)
        {
            float clampX = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            float clampY = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);
            transform.position = new Vector3(clampX, clampY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }

    // Tampilkan area batas di Scene view
    private void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            Gizmos.color = Color.green;
            Vector3 center = new Vector3((minBounds.x + maxBounds.x) / 2, (minBounds.y + maxBounds.y) / 2, 0);
            Vector3 size = new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 0);
            Gizmos.DrawWireCube(center, size);
        }
    }
}
