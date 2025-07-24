using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Green : MonoBehaviour
{
    public GameObject HUD_GREEN_COMMING_CAR2;
    public GameObject HUD_RED_COMMING_CAR2;


    private void OnTriggerEnter(Collider col)

        {
            if (col.gameObject.name == "On_Green" && !HUD_RED_COMMING_CAR2 )
            
            {
                HUD_GREEN_COMMING_CAR2.SetActive(true);
                HUD_RED_COMMING_CAR2.SetActive(false);

            }


        }
}
