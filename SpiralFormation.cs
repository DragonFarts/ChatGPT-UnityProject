using System.Collections;
using UnityEngine;

public class SpiralFormation : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float startRadius = 2.0f;
    public float endRadius = 5.0f;
    public float startHeight = 1.0f;
    public float endHeight = 2.0f;
    public float startWidth = 2.0f;
    public float endWidth = 4.0f;
    public float startDepth = 2.0f;
    public float endDepth = 4.0f;
    public float startAngleX = 0.0f;
    public float startAngleY = 45.0f;
    public float startAngleZ = 0.0f;
    public float endAngleX = 0.0f;
    public float endAngleY = 45.0f;
    public float endAngleZ = 0.0f;
    public float rotationSpeed = 10.0f;
    public float startSpacingX = 0.0f;
    public float startSpacingY = 0.5f;
    public float startSpacingZ = 0.0f;
    public float endSpacingX = 0.0f;
    public float endSpacingY = 0.5f;
    public float endSpacingZ = 0.0f;
    public float timeIncrement = 0.1f;
    public int stepCount = 7;

    void Start()
    {
        InvokeRepeating("GenerateFormation", 0f, timeIncrement);
    }

    void GenerateFormation()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        float radiusDelta = (endRadius - startRadius) / numberOfObjects;
        float heightDelta = (endHeight - startHeight) / numberOfObjects;
        float widthDelta = (endWidth - startWidth) / numberOfObjects;
        float depthDelta = (endDepth - startDepth) / numberOfObjects;
        float angleXDelta = (endAngleX - startAngleX) / numberOfObjects;
        float angleYDelta = (endAngleY - startAngleY) / numberOfObjects;
        float angleZDelta = (endAngleZ - startAngleZ) / numberOfObjects;
        float spacingXDelta = (endSpacingX - startSpacingX) / numberOfObjects;
        float spacingYDelta = (endSpacingY - startSpacingY) / numberOfObjects;
        float spacingZDelta = (endSpacingZ - startSpacingZ) / numberOfObjects;

        float rotationIncrement = 360.0f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float theta = i * Mathf.PI * 2 / numberOfObjects;
            float phi = Mathf.PI * 2 * (startHeight + i * heightDelta) * i / numberOfObjects;
            float radius = startRadius + i * radiusDelta;

            float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(phi) * Mathf.Sin(theta);
            float z = radius * Mathf.Cos(phi);

            Vector3 pos = new Vector3(x, y, z);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, pos);

            GameObject clone = Instantiate(prefab, pos, rot);
            clone.transform.parent = transform;

            clone.transform.position = new Vector3(clone.transform.position.x + i * (startSpacingX + i * spacingXDelta), clone.transform.position.y + i * (startSpacingY + i * spacingYDelta), clone.transform.position.z + i * (startSpacingZ + i * spacingZDelta));
            clone.transform.localScale = new Vector3(startWidth + i * widthDelta, startHeight + i * heightDelta, startDepth + i * depthDelta);
            clone.transform.Rotate(Vector3.right * (startAngleX + i * angleXDelta), Space.World);
            clone.transform.Rotate(Vector3.up * (startAngleY + i * angleYDelta), Space.World);
            clone.transform.Rotate(Vector3.forward * (startAngleZ + i * angleZDelta), Space.World);

            int step = i % stepCount;
            float colorValue = (float)step / (stepCount - 1);
            clone.GetComponent<Renderer>().material.color = new Color(colorValue, colorValue, colorValue);
        }

        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed, Space.World);
    }
}
