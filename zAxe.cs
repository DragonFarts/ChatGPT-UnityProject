using UnityEngine;

public class zAxe : MonoBehaviour
{
    public float zoomSpeed = 0.01f;
    public float zoomInterval = 0.01f;

    private Camera mainCamera;
    private float zoomTimer = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        zoomTimer += Time.deltaTime;

        if (zoomTimer >= zoomInterval)
        {
            zoomTimer -= zoomInterval;
            mainCamera.orthographicSize += zoomSpeed;
        }
    }
}
