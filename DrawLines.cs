using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public float interval = 5.0f;
    public float startWidth = 0.1f;
    public float endWidth = 0.1f;
    public GameObject parentGameObject;

    private LineRenderer lineRenderer;
    private int positionCount;

    private void Start()
    {
        InvokeRepeating("UpdateLine", 0, interval);
    }

    private void UpdateLine()
    {
        lineRenderer = GetComponent<LineRenderer>();
        positionCount = parentGameObject.transform.childCount;
        lineRenderer.positionCount = positionCount;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;

        Vector3[] positions = new Vector3[positionCount];
        for (int i = 0; i < positionCount; i++)
        {
            positions[i] = parentGameObject.transform.GetChild(i).position;
        }

        lineRenderer.SetPositions(positions);
    }
}
