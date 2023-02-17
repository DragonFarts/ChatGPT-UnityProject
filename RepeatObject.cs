using UnityEngine;

public class RepeatObject : MonoBehaviour
{
    public GameObject gameObjectToRepeat;
    public int repeatX = 1;
    public int repeatY = 1;
    public int repeatZ = 1;
    public float spaceBetweenX = 1.0f;
    public float spaceBetweenY = 1.0f;
    public float spaceBetweenZ = 1.0f;
    public float rotationXForX = 0.0f;
    public float rotationYForX = 0.0f;
    public float rotationZForX = 0.0f;
    public float rotationXForY = 0.0f;
    public float rotationYForY = 0.0f;
    public float rotationZForY = 0.0f;
    public float rotationXForZ = 0.0f;
    public float rotationYForZ = 0.0f;
    public float rotationZForZ = 0.0f;
    public float startRotationX = 0.0f;
    public float startRotationY = 0.0f;
    public float startRotationZ = 0.0f;

    private void Start()
    {
        // Call the UpdateValues function every 1000 milliseconds
        InvokeRepeating("UpdateValues", 0f, 1000f);
    }

    private void UpdateValues()
    {
        // Update the values of the variables here

        // ...

        // Re-create the objects based on the updated values
        CreateObjects();
    }

    private void CreateObjects()
    {
        for (int i = 0; i < repeatX; i++)
        {
            for (int j = 0; j < repeatY; j++)
            {
                for (int k = 0; k < repeatZ; k++)
                {
                    GameObject clone = Instantiate(gameObjectToRepeat, transform.position + new Vector3(i * spaceBetweenX, j * spaceBetweenY, k * spaceBetweenZ), Quaternion.identity);
                    clone.transform.parent = transform;
                    clone.transform.Rotate(rotationXForX * i, rotationYForX * i, rotationZForX * i);
                    clone.transform.Rotate(rotationXForY * j, rotationYForY * j, rotationZForY * j);
                    clone.transform.Rotate(rotationXForZ * k, rotationYForZ * k, rotationZForZ * k);
                    clone.transform.Rotate(startRotationX, startRotationY, startRotationZ);
                }
            }
        }
    }
}
