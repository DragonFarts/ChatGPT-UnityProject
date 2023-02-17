using UnityEngine;

public class Rota3uy : MonoBehaviour
{
    public GameObject gameObjectToRotate;
    public float timer = 1.0f;
    public float positiveRotation = 30.0f;
    public float negativeRotation = -30.0f;
    public bool rotateOnX = false;
    public bool rotateOnY = false;
    public bool rotateOnZ = true;

    private float startTime;
    private float journeyLength;
    private bool rotatingPositive = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Mathf.Abs(positiveRotation - negativeRotation);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * journeyLength / timer;
        float fracJourney = distCovered / journeyLength;

        float currentRotation;
        if (rotatingPositive)
        {
            currentRotation = Mathf.Lerp(negativeRotation, positiveRotation, fracJourney);
            if (currentRotation >= positiveRotation)
            {
                rotatingPositive = false;
                startTime = Time.time;
            }
        }
        else
        {
            currentRotation = Mathf.Lerp(positiveRotation, negativeRotation, fracJourney);
            if (currentRotation <= negativeRotation)
            {
                rotatingPositive = true;
                startTime = Time.time;
            }
        }

        Vector3 newRotation = gameObjectToRotate.transform.rotation.eulerAngles;
        if (rotateOnX)
        {
            newRotation.x = currentRotation;
        }
        if (rotateOnY)
        {
            newRotation.y = currentRotation;
        }
        if (rotateOnZ)
        {
            newRotation.z = currentRotation;
        }

        gameObjectToRotate.transform.rotation = Quaternion.Euler((newRotation)/10);
    }
}