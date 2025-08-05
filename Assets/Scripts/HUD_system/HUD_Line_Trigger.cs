using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Line_Trigger : MonoBehaviour
{
    public GameObject HUD_Red_line;
    public GameObject HUD_Green_line;
    // public GameObject HUD_GREEN_COMMING_CAR;
    // public GameObject HUD_RED_COMMING_CAR;
    // public GameObject HUD_GREEN_COMMING_CAR2;
    // public GameObject HUD_RED_COMMING_CAR2;
    // public GameObject[] HUD_GREEN_2way_CAR;
    // public GameObject[] HUD_RED_2way_CAR;
    public GameObject hypassleft;
    public GameObject hypassright;

    // Start is called before the first frame update
    void Start()
    {
        HUD_Green_line.SetActive(false);
        HUD_Red_line.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Start")
        {
            HUD_Green_line.SetActive(true);
            HUD_Red_line.SetActive(false);
            // HUD_GREEN_COMMING_CAR.SetActive(true);
            // HUD_RED_COMMING_CAR.SetActive(false);
            // HUD_GREEN_COMMING_CAR2.SetActive(true);
            // HUD_RED_COMMING_CAR2.SetActive(false);
                     
            
            // for (int i = 0; i < 3; i++)
            // {
            //     HUD_GREEN_2way_CAR[i].SetActive(true);
            //     HUD_RED_2way_CAR[i].SetActive(false);
                
            // }
        }
        if (col.gameObject.tag == "End")
        {
            HUD_Red_line.SetActive(false);
            HUD_Green_line.SetActive(false);
            // HUD_GREEN_COMMING_CAR.SetActive(false);
            // HUD_RED_COMMING_CAR.SetActive(false);
            // HUD_GREEN_COMMING_CAR2.SetActive(false);
            // HUD_RED_COMMING_CAR2.SetActive(false);
            // for (int i = 0; i < 3; i++)
            // {
            //     HUD_GREEN_2way_CAR[i].SetActive(false);
            //     HUD_RED_2way_CAR[i].SetActive(false);
                
            // }

        }
         if (col.gameObject.tag == "truck")
            
        {            
            
            
            HUD_Green_line.SetActive(false);
            HUD_Red_line.SetActive(true);
            // HUD_GREEN_COMMING_CAR.SetActive(false);
            // HUD_RED_COMMING_CAR.SetActive(true);
            // HUD_GREEN_COMMING_CAR2.SetActive(false);
            // HUD_RED_COMMING_CAR2.SetActive(true);
            // for (int i = 0; i < 3; i++)
            // {
            //     HUD_GREEN_2way_CAR[i].SetActive(false);
            //     HUD_RED_2way_CAR[i].SetActive(true);
                
            // }
            //     Debug.Log("충돌위험");
            
            
        }

        

        
    }
    //  private void OnTriggerStay(Collider col)
    // {
    //     if (col.gameObject.tag == "left")
    //     {
    //         hypassright.SetActive(false);

    //     }
    //    if (col.gameObject.tag == "right")
    //    {
    //        hypassleft.SetActive(false);
    //    }
    // }

   
    
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
        HUD_Green_line.SetActive(true);
        HUD_Red_line.SetActive(false);
    //     HUD_GREEN_COMMING_CAR.SetActive(true);
    //     HUD_RED_COMMING_CAR.SetActive(false);
    //     HUD_GREEN_COMMING_CAR2.SetActive(true);
    //     HUD_RED_COMMING_CAR2.SetActive(false);
    //    for (int i = 0; i < 3; i++)
    //         {
    //             HUD_GREEN_2way_CAR[i].SetActive(true);
    //             HUD_RED_2way_CAR[i].SetActive(false);
                
    //         }


        yield return null;
    }
      IEnumerator hudoff()
    {
        HUD_Green_line.SetActive(false);
        HUD_Red_line.SetActive(false);
        // HUD_GREEN_COMMING_CAR.SetActive(false);
        // HUD_RED_COMMING_CAR.SetActive(false);
        // HUD_GREEN_COMMING_CAR2.SetActive(false);
        // HUD_RED_COMMING_CAR2.SetActive(false);
        // for (int i = 0; i < 4; i++)
        //     {
        //         HUD_GREEN_2way_CAR[i].SetActive(false);
        //         HUD_RED_2way_CAR[i].SetActive(false);
                
        //     }
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
