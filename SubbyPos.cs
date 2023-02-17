using UnityEngine;

public class SubbyPos : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public float amountSubtracted;
    public float timeBetweenSubtractingAmount;

    public bool moveOnX;
    public bool moveOnY;
    public bool moveOnZ;

    public float multiplier = 1.1f;
    private int currentStep = 0;

    private float elapsedTime;

    private float currentX;
    private float currentY;
    private float currentZ;

    void Start()
    {
        currentX = 0;
        currentY = 0;
        currentZ = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenSubtractingAmount)
        {
            elapsedTime = 0;
            float moveAmount = 0f;

            if (moveOnX)
            {
                currentX -= amountSubtracted * Mathf.Pow(multiplier, currentStep);
                moveAmount = currentX - gameObjectToMove.transform.position.x;
            }
            if (moveOnY)
            {
                currentY -= amountSubtracted * Mathf.Pow(multiplier, currentStep);
                gameObjectToMove.transform.position = new Vector3(gameObjectToMove.transform.position.x, currentY, gameObjectToMove.transform.position.z);
            }
            if (moveOnZ)
            {
                currentZ -= amountSubtracted * Mathf.Pow(multiplier, currentStep);
                moveAmount = currentZ - gameObjectToMove.transform.position.z;
            }

            gameObjectToMove.transform.position -= new Vector3(moveOnX ? moveAmount : 0f, 0f, moveOnZ ? moveAmount : 0f);

            currentStep++;
        }
    }
}
