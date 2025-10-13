using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTransition : MonoBehaviour
{
    [Header("Target Area Settings")]
    public Transform newPlayerPosition;
    public Vector2 newMinBounds;
    public Vector2 newMaxBounds;

    [Header("Transition FX")]
    public Animator transitionAnim; // untuk efek fade in/out (opsional)
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Transition(other.transform));
        }
    }

    private System.Collections.IEnumerator Transition(Transform player)
    {
        // Kalau ada animasi fade, mainkan
        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }

        // Pindahkan player
        player.position = newPlayerPosition.position;

        // Ubah batas kamera (jika pakai CameraFollow manual)
        CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
        if (cam != null)
        {
            cam.minBounds = newMinBounds;
            cam.maxBounds = newMaxBounds;
        }

        // Fade in lagi
        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("End");
        }
    }
}
