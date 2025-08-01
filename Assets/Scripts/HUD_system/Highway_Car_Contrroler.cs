using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highway_Car_Contrroler : MonoBehaviour
{
// Start is called before the first frame update
    public WheelCollider[] wheels = new WheelCollider[4]; //
    public GameObject[] wheelMeshs = new GameObject[4];   //
    public float Torque = 100f; // ������ ȸ����ų ��
    
    public float speedLimit = 200f;
    public float speed;
    
    

    public GameObject CenterOfMass;



    private void Start()
    {
       
    }


    private void FixedUpdate()
    {
        //moveCar();
        
        animateWheelMeshs();



    }


    private void OnTriggerStay(Collider col)
    
    {
        if (col.gameObject.tag == "breaking" || col.gameObject.tag == "truck")
        {
          StopCar();
        }
        

        
    }

    private void OnTriggerExit(Collider col)
    
    {
        if (col.gameObject.tag == "breaking")
        {
          moveCar();
        }
        

        
    }

    public void moveCar()
    {
       

        speed = gameObject.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        /*gameObject.GetComponent<Rigidbody>().centerOfMass = CenterOfMass.transform.localPosition;*/
        if (speed <= speedLimit)
        {
            for (int i = 0; i < 4; i++)
            {

                wheels[i].brakeTorque = 0f;
                wheels[i].motorTorque = Torque;


            }
        }
    }

    public void StopCar()
    {
       

       
            for (int i = 0; i < 4; i++)
            {


                  wheels[i].brakeTorque = 10000000f;


            }
        
    }
    private void animateWheelMeshs() // 휠 메쉬 보이는 거 조절 
    {
        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out pos, out rot);
            wheelMeshs[i].transform.position = pos;
            wheelMeshs[i].transform.rotation = rot;
        }
    }
}
