using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_guideLine_Controller : MonoBehaviour
{
    public GameObject[] allHUDImages;

    public GameObject leftHard1;
    public GameObject leftHard2;
    public GameObject leftHard3;
    public GameObject leftHard4;
    public GameObject leftHard5;
    public GameObject leftHard6;
    public GameObject leftHard7;

    public GameObject straight;
  
    public GameObject rightHard;
    //운전자 인풋관련 
    [SerializeField] private DemoCarController controller;
    private void FixedUpdate()
    {
        float steeringAngle = controller.rawSteeringInput * 30;
        
        Debug.Log(steeringAngle);

        UpdateHUDBySteering(steeringAngle);
    }
    void UpdateHUDBySteering(float steeringAngle)
    {
        // 예시 범위: -30~30도
        if (steeringAngle < -4 && steeringAngle>= -8)
            ShowHUD(leftHard1);
        else if (steeringAngle < -8 && steeringAngle>= -12)
            ShowHUD(leftHard2);
        else if(steeringAngle < -12 && steeringAngle>= -16)
            ShowHUD(leftHard3);
        else if(steeringAngle < -16 && steeringAngle>= -20)
            ShowHUD(leftHard4);
        else if(steeringAngle < -20 && steeringAngle>= -24)
            ShowHUD(leftHard5);
        else if(steeringAngle < -24 && steeringAngle>= -28)
            ShowHUD(leftHard6);
        else if(steeringAngle < -28)
            ShowHUD(leftHard7);

    

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
