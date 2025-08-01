using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highway_Car_Trigger : MonoBehaviour
{
    [SerializeField] private Highway_Car_Contrroler Highway_Car_Contrroler;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider col)
    
    {
        if (col.gameObject.name == "HUD_tester")
        {
           Highway_Car_Contrroler.moveCar();
        }
        

        
    }
}
