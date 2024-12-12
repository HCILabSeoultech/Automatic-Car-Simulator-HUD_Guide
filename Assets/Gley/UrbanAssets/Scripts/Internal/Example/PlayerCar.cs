using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static Controller;
using System.IO;

namespace Gley.UrbanSystem.Internal
{
    /// <summary>
    /// This class is for testing purpose only
    /// It is the car controller provided by Unity:
    /// https://docs.unity3d.com/Manual/WheelColliderTutorial.html
    /// </summary>
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
    }


    public class PlayerCar : MonoBehaviour
    {
        public GameObject Car3;
        public GameObject LeftCar2;
        public List<AxleInfo> axleInfos;
        public Transform centerOfMass;
        public float maxMotorTorque;
        public float maxSteeringAngle;


        //자동차 Ai 관련
        public trackWaypoints waypoints;
        public Transform currentWaypoint;
        public List<Transform> nodes = new List<Transform>();
        public int distanceOffset = 1;
        public float sterrForce = 1f;
        //end

        IVehicleLightsComponent lightsComponent;
        bool mainLights;
        bool brake;
        bool reverse;
        bool blinkLeft;
        bool blinkRifgt;
        float realtimeSinceStartup;
        float speed = 0.2f;
        int status = 0;
        Rigidbody rb;

        float handleInput = 0.0f;   // 핸들 입력 (-1 ~ 1)
       
        UIInput inputScript;


        private void Start()
        {
            GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
            inputScript = gameObject.AddComponent<UIInput>().Initialize();
            lightsComponent = gameObject.GetComponent<VehicleLightsComponent>();
            lightsComponent.Initialize();
            rb = GetComponent<Rigidbody>();
            status = 0;
        }

        private void Awake()
        {
            //자율주행을 위한 루트
            waypoints = GameObject.FindGameObjectWithTag("path").GetComponent<trackWaypoints>();
            nodes = waypoints.nodes;
        }

        // finds the corresponding visual wheel
        // correctly applies the transform
        public void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0)
            {
                return;
            }

            Transform visualWheel = collider.transform.GetChild(0);

            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }

        public void FixedUpdate()
        {
            calculateDistanceOfWaypoints();// 현재위치 way포인트
            float motor = maxMotorTorque * speed;
            float steering = maxSteeringAngle * handleInput;

            if (status == 1) AISteer();

            float localVelocity = transform.InverseTransformDirection(rb.velocity).z+0.1f;
            reverse = false;
            brake = false;
            if (localVelocity < 0)
            {
                reverse = true;
            }

            if (motor < 0)
            {
                if (localVelocity > 0)
                {
                    brake = true;
                }
            }
            else
            {
                if (motor > 0)
                {
                    if (localVelocity < 0)
                    {
                        brake = true;
                    }
                }
            }

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }

            //Debug.Log(handleInput);

            
        }

        private void Update()
        {
            realtimeSinceStartup += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mainLights = !mainLights;
                lightsComponent.SetMainLights(mainLights);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                blinkLeft = !blinkLeft;
                if (blinkLeft == true)
                {
                    blinkRifgt = false;
                    lightsComponent.SetBlinker(BlinkType.BlinkLeft);
                }
                else
                {
                    lightsComponent.SetBlinker(BlinkType.Stop);
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                blinkRifgt = !blinkRifgt;
                if (blinkRifgt == true)
                {
                    blinkLeft = false;
                    lightsComponent.SetBlinker(BlinkType.BlinkRight);
                }
                else
                {
                    lightsComponent.SetBlinker(BlinkType.Stop);
                }
            }

           

            lightsComponent.SetBrakeLights(brake);
            lightsComponent.SetReverseLights(reverse);
            lightsComponent.UpdateLights(realtimeSinceStartup);
        }

        void OnTriggerEnter(Collider col)
        {
            //시나리오2번 스트레스 관련 답답하게 만들기 느리게 갔다가 한차가 빨라짐 
            if (col.gameObject.name == "test2_stress_speedUp")
            {
                speed = 0.3f;
            }

            if (col.gameObject.name == "test2_stress_speedDown")
            {
                speed = 0.2f;
            }

            //시나리오 2번 화 두려움 운전자가 빡치게 만들게 끼어들게 만들기 Car3만 해당함 
            if(col.gameObject.name == "tester")
            {

                status = 1;
                

            }


           

            if (col.gameObject.name == "test2_afraid_end")
            {
                
                if(Car3 != null)
                {
                    Car3.SetActive(false);
                }
                else 
                {
                    status = status;
                }

            }

            if(col.gameObject.name == "stay1way")
            {
                LeftCar2.SetActive(false);
            }
        }

    

        private void calculateDistanceOfWaypoints()
        {
            Vector3 position = gameObject.transform.position; // 자동차의 위치 
            float shortestDistance = Mathf.Infinity;

            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 difference = nodes[i].position - position; // 웨이포인트와 자동차의 거리
                float currentDistance = difference.magnitude;
                if (currentDistance < shortestDistance)
                {
                    int nextIndex = (i + 1) % nodes.Count; // 다음 웨이포인트의 인덱스 계산
                    currentWaypoint = nodes[nextIndex];
                    shortestDistance = currentDistance;
                }
            }
        }

        private void AISteer()
        {
            Vector3 relative = transform.InverseTransformPoint(currentWaypoint.transform.position);
            relative /= relative.magnitude;

            handleInput = (relative.x / relative.magnitude) * sterrForce;

        }


        private void OnDrawGizmos()
        {
            //Gizmos.DrawWireSphere(currentWaypoint.position, 3);
        }
        //Ai기능 켜지면 꼭 킬것




    }
}