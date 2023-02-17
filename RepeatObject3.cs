using UnityEngine;

[ExecuteInEditMode]
public class RepeatObject3 : MonoBehaviour
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
    public float positionXForX = 0.0f;
    public float positionYForX = 0.0f;
    public float positionZForX = 0.0f;
    public float positionXForY = 0.0f;
    public float positionYForY = 0.0f;
    public float positionZForY = 0.0f;
    public float positionXForZ = 0.0f;
    public float positionYForZ = 0.0f;
    public float positionZForZ = 0.0f;
    public float timer = 0.108f;

    private float timeSinceLastUpdate;

    private void OnEnable()
    {
        CreateObjects();
        timeSinceLastUpdate = 0.0f;
    }

    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= timer)
        {
            CreateObjects();
            timeSinceLastUpdate = 0.0f;
        }
    }

    private void CreateObjects()
    {
        // Destroy existing objects
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        // Create new objects
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
                    clone.transform.position += new Vector3(positionXForX * i, positionYForX * i, positionZForX * i);
                    clone.transform.position += new Vector3(positionXForY * j, positionYForY * j, positionZForY * j);
                    clone.transform.position += new Vector3(positionXForZ * k, positionYForZ * k, positionZForZ * k);

                    clone.transform.Rotate(gameObjectToRepeat.transform.rotation.eulerAngles);
;
;
                }
            }
        }
    }
}
