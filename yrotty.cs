using UnityEngine;

public class yrotty : MonoBehaviour
{
    public GameObject insertGameObject;
    public float startRotation = -90f;
    public float endRotation = -30f;
    public float rotationSpeed = 0.001f;
    public float startSpeed = 0.001f;
    public float endSpeed = -0.001f;
    public float startDelay = 0f;
    public float endDelay = 0f;

    private Quaternion startRotationQuaternion;
    private float currentRotation;
    private float currentSpeed;
    private bool isReversing;

    void Start()
    {
        startRotationQuaternion = insertGameObject.transform.rotation;
        currentRotation = startRotation;
        currentSpeed = startSpeed;
        InvokeRepeating("RotateObject", startDelay, rotationSpeed);
    }

    void RotateObject()
    {
        if (isReversing)
        {
            currentRotation += currentSpeed;
            if (currentRotation <= endRotation)
            {
                currentRotation = endRotation;
                currentSpeed = endSpeed;
                isReversing = false;
                Invoke("StartReversing", endDelay);
            }
        }
        else
        {
            currentRotation += currentSpeed;
            if (currentRotation >= endRotation)
            {
                currentRotation = endRotation;
                currentSpeed = endSpeed;
                isReversing = true;
                Invoke("StartReversing", endDelay);
            }
        }
        Quaternion newRotation = Quaternion.Euler(currentRotation, startRotationQuaternion.eulerAngles.y, startRotationQuaternion.eulerAngles.z);
        insertGameObject.transform.rotation = newRotation;
    }

    void StartReversing()
    {
        float yRotation = insertGameObject.transform.rotation.eulerAngles.y;
        if (yRotation >= 180f)
        {
            yRotation -= 360f;
        }
        if (isReversing)
        {
            if (yRotation <= endRotation)
            {
                isReversing = false;
            }
        }
        else
        {
            if (yRotation >= startRotation)
            {
                isReversing = true;
            }
        }
    }
}
