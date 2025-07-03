using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTriggerMover : MonoBehaviour
{
    public Transform targetObj;       // 움직일 오브젝트
    public Vector3 moveDirection = Vector3.forward;  // 이동 방향
    public float moveSpeed = 2f;         // 이동 속도

    private bool shouldMove = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OBJ: {other.name}");
        if (other.CompareTag("Player"))  // 유저 또는 차량 태그
        {
            shouldMove = true;
        }
    }

    void Update()
    {
        if (shouldMove && targetObj != null)
        {
            targetObj.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
