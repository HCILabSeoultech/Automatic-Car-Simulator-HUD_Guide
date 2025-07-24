using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Lenth_contrroler : MonoBehaviour
{
public Transform hudLine;  // Cube 오브젝트 (중앙 pivot)
public Transform hudOrigin; // HUD 기준점
public Transform vehicle;
void Update()
{
    float distance = Vector3.Distance(vehicle.position, hudOrigin.position);
    float hudLength = Mathf.Clamp(distance, 0f, 20f);

    // 1. 길이 조절
    Vector3 scale = hudLine.localScale;
    scale.z = hudLength;
    hudLine.localScale = scale;

    // 2. 보정된 위치 조절
    hudLine.localPosition = new Vector3(0, 0, hudLength / 2f);

   
}
}