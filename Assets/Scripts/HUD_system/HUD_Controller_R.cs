using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Controller_R : MonoBehaviour
{
    public GameObject HUD_SUR_Trig;
    public GameObject HUD_LINE_Trig;
    public GameObject HUD_ROAD_SUR_Trig;
    public GameObject HUD_ROAD_LINE_Trig;
    public GameObject HUD_SUR_Trig_ComCar1;
    public GameObject HUD_LINE_Trig_ComCar1;

    // Start is called before the first frame update
    void Start()
    {
        HUD_SUR_Trig.SetActive(false);
        HUD_LINE_Trig.SetActive(false);
        HUD_ROAD_SUR_Trig.SetActive(true);
        HUD_ROAD_LINE_Trig.SetActive(false);
        HUD_SUR_Trig_ComCar1.SetActive(true);
        HUD_LINE_Trig_ComCar1.SetActive(false);

    }
}