using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommingCar2_Trigger : MonoBehaviour
{
   [SerializeField] private ComminCar_Contrroler2 comming_Car_Contrroler;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider col)
    
    {
        if (col.gameObject.name == "HUD_tester")
        {
           comming_Car_Contrroler.moveCar();
        }
        

        
    }
}
