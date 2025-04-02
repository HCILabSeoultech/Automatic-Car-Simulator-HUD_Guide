using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_guideLine_Controller : MonoBehaviour
{
    public GameObject[] allHUDImages;

    public GameObject leftHard;

    public GameObject straight;
  
    public GameObject rightHard;
    //운전자 인풋관련 
    [SerializeField] private DemoCarController controller;
    private void FixedUpdate()
    {
        float steeringAngle = controller.rawSteeringInput * 450;
        
        Debug.Log(steeringAngle);

        UpdateHUDBySteering(steeringAngle);
    }
    void UpdateHUDBySteering(float steeringAngle)
    {
        // 예시 범위: -30~30도
        if (steeringAngle < -20)
            ShowHUD(leftHard);

        else if (steeringAngle > 20)
            ShowHUD(rightHard);

        else
            ShowHUD(straight);
    }

    void ShowHUD(GameObject target)
    {
        foreach (GameObject obj in allHUDImages)
            obj.SetActive(obj == target);
    }


}
