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
         if (col.gameObject.tag == "truck")
            
        {            
            
            
                HUD_Green.SetActive(false);
                HUD_Red.SetActive(true);
                Debug.Log("충돌위험");
            
            
        }

        
    }

   
    
    private void OnTriggerExit(Collider col)
    {
        
        {
            if (col.gameObject.tag == "truck")
            {
                StartCoroutine(hudGreenOn());
                Debug.Log("벗어남");
            }
        }
    }

    IEnumerator hudGreenOn_off()
    {
        yield return StartCoroutine(hudGreenOn());
        yield return StartCoroutine(hudoff());
    }



    IEnumerator hudGreenOn()
    {
        HUD_Green.SetActive(true);
        HUD_Red.SetActive(false);

        yield return null;
    }
      IEnumerator hudoff()
    {
        HUD_Green.SetActive(false);
        HUD_Red.SetActive(false);

        yield return null;
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
