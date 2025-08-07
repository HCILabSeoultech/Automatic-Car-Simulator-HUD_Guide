using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_controller : MonoBehaviour
{
    public GameObject truckstart;
    public GameObject truckend;
    public GameObject narrowstart;
    public GameObject narrowend;
    public GameObject commingcar1start;
    public GameObject commingcar1end;
    public GameObject commingcar2start;
    public GameObject commingcar2end;
    public GameObject parkingstart;
    public GameObject parkingend;
    public GameObject constructionstart;
    public GameObject constructionend;
    public GameObject hypassstart;
    public GameObject hypassend;
    public GameObject end;

    

    private void Start()
    {
        Debug.Log("실험시작");
    }
    void OnTriggerEnter(Collider col)
    {
        // truck start 
        if (col.gameObject.name == "Truck_start")
        {
            Debug.Log("event1 Truck_start");

        }

        // truck end
        if (col.gameObject.name == "Truck_end")
        {
            Debug.Log("event1 Truck_end");

        }
        
        // narrow start
        if (col.gameObject.name == "Narrow_raod_start")
        {
            Debug.Log("event2 Narrow_start");

        }
        // narrow end
        if (col.gameObject.name == "Narrow_raod_end")
        {
            Debug.Log("event2 Narrow_end");

        }
        // commingcar1 start
        if (col.gameObject.name == "Comming_Car_Start")
        {
            Debug.Log("event3 CommingCar1_start");

        }
        // commingcar1 end
        if (col.gameObject.name == "Comming_Car_End")
        {
            Debug.Log("event3 CommingCar1_end");

        }
        // commingcar2 start
        if (col.gameObject.name == "Comming_Car2_Start")
        {
            Debug.Log("event4 CommingCar2_start");

        }
        // commingcar2 end
        if (col.gameObject.name == "Comming_Car2_End")
        {
            Debug.Log("event4 CommingCar2_end");

        }
        // parking start
        if (col.gameObject.name == "Parking_start")
        {
            Debug.Log("event5 Parking_start");

        }
        // parking end
        if (col.gameObject.name == "Parking_end")
        {
            Debug.Log("event5 Parking_end");

        }
        // Construction start
        if (col.gameObject.name == "Construction_start")
        {
            Debug.Log("event6 Construction_start");

        }
        // Construction end
        if (col.gameObject.name == "Construction_end")
        {
            Debug.Log("event6 Construction_end");

        }
        // hipass start
        if (col.gameObject.name == "Hypass_start")
        {
            Debug.Log("event7 Hipass_start");

        }
        // hipass end
        if (col.gameObject.name == "Hypass_end")
        {
            Debug.Log("event7 Hipass_end");

        }
        // truck end
        if (col.gameObject.name == "end")
        {
            Debug.Log("실험 종료");

        }


    }
}
