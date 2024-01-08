using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 originalPosition;
    
    // Stärke des Camera Shakes
    public float shakeAmount;

    // Dauer des Camera Shakes
    public float shakeDuration;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Funktion für das Auslösen des Camera Shakes
    public void Shake()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform not found!");
            return;
        }

        originalPosition = cameraTransform.localPosition;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    void DoShake()
    {
        float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
        float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
        cameraTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        cameraTransform.localPosition = originalPosition;
    }
}
