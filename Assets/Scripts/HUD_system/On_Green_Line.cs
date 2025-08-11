using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Green_Line : MonoBehaviour
{
    public GameObject HUD_GREEN_LINE_COMMING_CAR;
    public GameObject HUD_RED_LINE_COMMING_CAR;

    void Start()
    {
                HUD_GREEN_LINE_COMMING_CAR.SetActive(false);
                HUD_RED_LINE_COMMING_CAR.SetActive(false);

    }

    private void OnTriggerEnter(Collider col)

        {
            if (col.gameObject.name == "On_Green" && HUD_RED_LINE_COMMING_CAR )
            
            {
                HUD_GREEN_LINE_COMMING_CAR.SetActive(true);
                HUD_RED_LINE_COMMING_CAR.SetActive(false);

            }


        }
}
