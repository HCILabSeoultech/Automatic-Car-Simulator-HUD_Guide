using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class TrajectoryMesh : MonoBehaviour
{
    
    [SerializeField] private DemoCarController controller;
    public float wheelBase = 2.705f;
    public float arcLength = 30f;
    public int segments = 20;
    public float lineWidth = 1.9f;
    

    private Mesh trajectoryMesh;

    void Start()
    {
        trajectoryMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = trajectoryMesh;
    }

    void FixedUpdate()
    {
        float steerAngle = controller.rawSteeringInput;
        GenerateTrajectoryMesh(steerAngle);
    }

    void GenerateTrajectoryMesh(float steerAngle)
    {
        steerAngle *= 30f;
        float steerRad = steerAngle * Mathf.Deg2Rad;

        Vector3[] points = new Vector3[segments + 1];

        if (Mathf.Abs(steerRad) < 0.001f)
        {
            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float x = arcLength * t;
                points[i] = new Vector3(x, 0f, 0f); // 직선 진행
            }
        }
        else
        {
            float radius = wheelBase / Mathf.Tan(steerRad);
            float phi = arcLength / Mathf.Abs(radius);
            float direction = Mathf.Sign(steerAngle);

            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float angle = phi * t * direction;

                float x = radius * Mathf.Sin(angle);
                float z = -radius * (1f - Mathf.Cos(angle));

                points[i] = new Vector3(x, 0f, z);
            }
        }

        BuildMeshFromPoints(points);
    }

    void BuildMeshFromPoints(Vector3[] points)
    {
        Vector3[] vertices = new Vector3[points.Length * 2];
        int[] triangles = new int[(points.Length - 1) * 6];

        for (int i = 0; i < points.Length; i++)
        {
            Vector3 forward = Vector3.zero;

            if (i == 0)
                forward = points[i + 1] - points[i];
            else if (i == points.Length - 1)
                forward = points[i] - points[i - 1];
            else
                forward = (points[i + 1] - points[i - 1]) * 0.5f;

            Vector3 side = Vector3.Cross(Vector3.up, forward.normalized);
            Vector3 left = points[i] - side * (lineWidth * 0.5f);
            Vector3 right = points[i] + side * (lineWidth * 0.5f);

            vertices[i * 2] = left;
            vertices[i * 2 + 1] = right;
        }

        for (int i = 0; i < points.Length - 1; i++)
        {
            int vi = i * 2;
            triangles[i * 6] = vi;
            triangles[i * 6 + 1] = vi + 2;
            triangles[i * 6 + 2] = vi + 1;

            triangles[i * 6 + 3] = vi + 2;
            triangles[i * 6 + 4] = vi + 3;
            triangles[i * 6 + 5] = vi + 1;
        }

        trajectoryMesh.Clear();
        trajectoryMesh.vertices = vertices;
        trajectoryMesh.triangles = triangles;
        trajectoryMesh.RecalculateNormals();
    }
}
