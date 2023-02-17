using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject gameObjectToAnimate;
    public float timer = 1.0f;
    public float positivePosition = 1.0f;
    public float negativePosition = -1.0f;
    public bool animateOnX = false;
    public bool animateOnY = false;
    public bool animateOnZ = true;

    private float startTime;
    private float journeyLength;
    private bool animatingPositive = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Mathf.Abs(positivePosition - negativePosition);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * journeyLength / timer;
        float fracJourney = distCovered / journeyLength;

        float currentPosition;
        if (animatingPositive)
        {
            currentPosition = Mathf.Lerp(negativePosition, positivePosition, fracJourney);
            if (currentPosition >= positivePosition)
            {
                animatingPositive = false;
                startTime = Time.time;
            }
        }
        else
        {
            currentPosition = Mathf.Lerp(positivePosition, negativePosition, fracJourney);
            if (currentPosition <= negativePosition)
            {
                animatingPositive = true;
                startTime = Time.time;
            }
        }

        Vector3 newPosition = gameObjectToAnimate.transform.position;
        if (animateOnX)
        {
            newPosition.x = currentPosition;
        }
        if (animateOnY)
        {
            newPosition.y = currentPosition;
        }
        if (animateOnZ)
        {
            newPosition.z = currentPosition;
        }

        gameObjectToAnimate.transform.position = newPosition;
    }
}
