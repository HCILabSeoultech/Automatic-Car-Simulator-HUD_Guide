using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    [SerializeField] private DemoCarController controller;     // 차량 조향값 받는 컨트롤러
    [SerializeField] private LineRenderer lineRenderer;         // 라인렌더러

    public float wheelBase = 2.705f;       // 차량 휠베이스
    public float arcLength = 30f;          // 궤적 길이
    public int segments = 20;              // 라인 세그먼트 개수
    public float lineWidth = 1.9f;         // 라인 폭 (차량 폭 기준)

    void FixedUpdate()
    {
        if (controller == null || lineRenderer == null)
            return;

        float steerAngle = controller.rawSteeringInput;
        DrawTrajectory(steerAngle);
    }

void DrawTrajectory(float steerAngle)
{
    float steerRad = steerAngle * Mathf.Deg2Rad * 30;

    if (Mathf.Abs(steerRad) < 0.001f)
    {
        Vector3[] straightPoints = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments;
            float x = arcLength * t;
            straightPoints[i] = new Vector3(x, 0f, 0f);
        }
        ApplyLine(straightPoints);
        return;
    }

    float radius = wheelBase / Mathf.Tan(steerRad);
    float phi = arcLength / Mathf.Abs(radius);
    float direction = Mathf.Sign(steerAngle);

    Vector3[] curvePoints = new Vector3[segments + 1];
    for (int i = 0; i <= segments; i++)
    {
        float t = (float)i / segments;
        float angle = phi * t * direction;

        float x = radius * Mathf.Sin(angle);
        float z = -radius * (1 - Mathf.Cos(angle)); // ✅ 여기 반전!

        curvePoints[i] = new Vector3(x, 0f, z);
    }

    ApplyLine(curvePoints);
}



    void ApplyLine(Vector3[] points)
    {
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }
}
