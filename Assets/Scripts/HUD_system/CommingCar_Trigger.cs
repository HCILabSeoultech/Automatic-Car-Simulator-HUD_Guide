using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommingCar_Trigger : MonoBehaviour
{
    [SerializeField] private Comming_Car_Contrroler comming_Car_Contrroler;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider col)
    
    {
        if (col.gameObject.name == "HUD_tester")
        {
           comming_Car_Contrroler.moveCar();
        }
        

        
    }
}
