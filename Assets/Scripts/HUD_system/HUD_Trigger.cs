using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Trigger : MonoBehaviour
{
    public GameObject HUD_Red;
    public GameObject HUD_Green;

    // Start is called before the first frame update
    void Start()
    {
        HUD_Green.SetActive(false);
        HUD_Red.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Start")
        {
            HUD_Green.SetActive(true);
            HUD_Red.SetActive(false);
        }
        if (col.gameObject.tag == "End")
        {
            HUD_Red.SetActive(false);
            HUD_Green.SetActive(false);
        }

        
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "truck")
        {
            HUD_Red.SetActive(true);
            HUD_Green.SetActive(false);
        }
    }

    // private void OnTriggerExit(Collider col)
    // {
    //     if(col.gameObject.tag == "HUD_system")
    //     {
    //         HUD_Green.SetActive(false);
    //         HUD_Red.SetActive(false);
    //     }
    // }
}
