using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpeedLimitAlarm : MonoBehaviour
{
    [Header("Settings")]
    public float speedLimit = 100f; // 제한 속도 (km/h)

    [Header("References")]
    public VolvoCars.Data.Velocity velocity;  // 차량 속도 데이터
    public GameObject warningObject;          // 과속 경고 표시 오브젝트

    private void Update()
    {
        if (velocity == null || warningObject == null) return;

        // 현재 속도 (m/s → km/h 변환)
        float speedKmh = Mathf.Abs(velocity.Value) * 3.6f;

        if (speedKmh > speedLimit)
        {
            // 과속 시 경고 객체 켜기
            if (!warningObject.activeSelf)
                warningObject.SetActive(true);
        }
        else
        {
            // 제한 속도 이하일 때 끄기
            if (warningObject.activeSelf)
                warningObject.SetActive(false);
        }
    }
}
