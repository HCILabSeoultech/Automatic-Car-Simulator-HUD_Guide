using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Green : MonoBehaviour
{
    public GameObject HUD_GREEN_COMMING_CAR;
    public GameObject HUD_RED_COMMING_CAR;


    private void OnTriggerEnter(Collider col)

        {
            if (col.gameObject.name == "On_Green" && HUD_RED_COMMING_CAR )
            
            {
                HUD_GREEN_COMMING_CAR.SetActive(true);
                HUD_RED_COMMING_CAR.SetActive(false);

            }


        }
}
