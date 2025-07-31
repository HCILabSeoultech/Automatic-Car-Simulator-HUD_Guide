using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_lenght_Trigger : MonoBehaviour
{
    public GameObject length_truck;
    public GameObject length_narrowRoad;
    public GameObject length_commingcar1;
    public GameObject length_commingcar2;
    public GameObject length_parking;
    public GameObject length_construction;
    public GameObject length_hypass;


    

   private void OnTriggerEnter(Collider col)
   {
    if (col.gameObject.name == "Truck_start")
    {
        length_truck.SetActive(true);
    }


    if (col.gameObject.name == "Narrow_raod_start")
    {
        length_narrowRoad.SetActive(true);
    }


    if (col.gameObject.name == "Comming_Car_Start")
    {
        length_commingcar1.SetActive(true);
    }
    if (col.gameObject.name == "Comming_Car2_Start")
    {
        length_commingcar1.SetActive(false);
        length_commingcar2.SetActive(true);
    }
    if (col.gameObject.name == "Parking_start")
    {
        length_parking.SetActive(true);
    }
    if (col.gameObject.name == "Hypass_start")
    {
        length_hypass.SetActive(true);
    }

    if (col.gameObject.tag == "End")
    {
        length_truck.SetActive(false);
        length_narrowRoad.SetActive(false);
        length_commingcar1.SetActive(false);
        length_commingcar2.SetActive(false);
        length_parking.SetActive(false);
        length_hypass.SetActive(false);
    }



   }
}
