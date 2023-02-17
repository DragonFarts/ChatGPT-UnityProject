using UnityEngine;

public class AddyRot : MonoBehaviour
{
    public GameObject gameObjectToRotate;
    public float amountAdded;
    public float timeBetweenAddingAmount;

    public bool rotateOnX;
    public bool rotateOnY;
    public bool rotateOnZ;

    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenAddingAmount)
        {
            elapsedTime = 0;
            Vector3 rotationAmount = Vector3.zero;

            if (rotateOnX)
            {
                rotationAmount.x = amountAdded;
            }
            if (rotateOnY)
            {
                rotationAmount.y = amountAdded;
            }
            if (rotateOnZ)
            {
                rotationAmount.z = amountAdded;
            }

            gameObjectToRotate.transform.Rotate(rotationAmount);
        }
    }
}
