using UnityEngine;

public class TrajectoryDualLine : MonoBehaviour
{
   [SerializeField] private DemoCarController controller;

    [Header("설정")]
    public float wheelBase = 2.705f;
    public float arcLength = 30f;
    public int segments = 20;
    public float lineWidth = 1.9f;

    [Header("기존 LineRenderer 연결")]
    public LineRenderer leftLine;
    public LineRenderer rightLine;

    void Start()
    {
        // 꼭 에디터에서 연결할 것
        if (!leftLine || !rightLine)
        {
            Debug.LogError("LineRenderer가 연결되지 않았습니다.");
            enabled = false;
            return;
        }

        leftLine.positionCount = segments + 1;
        rightLine.positionCount = segments + 1;
    }

    void FixedUpdate()
    {
        float steerAngle = controller.rawSteeringInput;
        Vector3[] centerPoints = GenerateCenterTrajectory(steerAngle);
        ApplyToLineRenderers(centerPoints);
    }

    Vector3[] GenerateCenterTrajectory(float steerInput)
    {
        steerInput *= 30f;
        float steerRad = steerInput * Mathf.Deg2Rad;
        Vector3[] points = new Vector3[segments + 1];

        if (Mathf.Abs(steerRad) < 0.001f)
        {
            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float x = arcLength * t;
                points[i] = new Vector3(x, 0f, 0f);
            }
        }
        else
        {
            float radius = wheelBase / Mathf.Tan(steerRad);
            float phi = arcLength / Mathf.Abs(radius);
            float direction = Mathf.Sign(steerInput);

            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float angle = phi * t * direction;

                float x = radius * Mathf.Sin(angle);
                float z = -radius * (1f - Mathf.Cos(angle));
                points[i] = new Vector3(x, 0f, z);
            }
        }

        return points;
    }

    void ApplyToLineRenderers(Vector3[] centerPoints)
    {
        Vector3[] leftPoints = new Vector3[centerPoints.Length];
        Vector3[] rightPoints = new Vector3[centerPoints.Length];

        for (int i = 0; i < centerPoints.Length; i++)
        {
            Vector3 forward;
            if (i == 0)
                forward = centerPoints[i + 1] - centerPoints[i];
            else if (i == centerPoints.Length - 1)
                forward = centerPoints[i] - centerPoints[i - 1];
            else
                forward = (centerPoints[i + 1] - centerPoints[i - 1]) * 0.5f;

            Vector3 side = Vector3.Cross(Vector3.up, forward.normalized);

            leftPoints[i] = centerPoints[i] - side * (lineWidth * 0.5f);
            rightPoints[i] = centerPoints[i] + side * (lineWidth * 0.5f);
        }

        leftLine.SetPositions(leftPoints);
        rightLine.SetPositions(rightPoints);
    }
}
