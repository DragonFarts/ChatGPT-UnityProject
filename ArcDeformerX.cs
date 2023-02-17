using UnityEngine;

[ExecuteInEditMode]
public class ArcDeformerX : MonoBehaviour
{
    public int segments = 36;
    public float outerRadius = 3.0f;
    public float innerRadius = 1.0f;
    public float angle = 360.0f;
    public Vector3 position = new Vector3(0, 0, 0);

    private MeshFilter meshFilter;
    private Mesh mesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        UpdateMesh();
    }

    void Update()
    {
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        Vector3[] vertices = new Vector3[segments * 2 + 2];
        int[] triangles = new int[segments * 6];

        float angleStep = angle / segments;

        vertices[0] = new Vector3(0, 0, 0) + position;
        for (int i = 0; i < segments; i++)
        {
            float rad = Mathf.Deg2Rad * (i * angleStep);
            float c = Mathf.Cos(rad);
            float s = Mathf.Sin(rad);

            vertices[i * 2 + 1] = new Vector3(c * outerRadius, s * outerRadius, 0) + position;
            vertices[i * 2 + 2] = new Vector3(c * innerRadius, s * innerRadius, 0) + position;

            int i2 = i * 2;
            int v1 = i2 + 1;
            int v2 = i2 + 2;
            int v3 = ((i2 + 3) % (segments * 2)) + 1;
            int v4 = ((i2 + 4) % (segments * 2)) + 1;

            triangles[i2 * 3] = v1;
            triangles[i2 * 3 + 1] = v2;
            triangles[i2 * 3 + 2] = v3;

            triangles[i2 * 3 + 3] = v2;
            triangles[i2 * 3 + 4] = v4;
            triangles[i2 * 3 + 5] = v3;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
