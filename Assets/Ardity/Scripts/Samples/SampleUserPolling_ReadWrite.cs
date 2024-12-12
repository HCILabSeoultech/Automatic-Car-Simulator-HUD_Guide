/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    LogitechGSDK.LogiControllerPropertiesData properties;
    int calicount = 0;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

       

        
       
      
    }

    // Executed each frame
    void Update()
    {
        LogitechGSDK.DIJOYSTATE2ENGINES rec;
        rec = LogitechGSDK.LogiGetStateUnity(0);


        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.




        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    calicount++;
        //    if (calicount == 1)
        //    {
        //        Debug.Log("Cali모드 시작");
        //        serialController.SendSerialMessage("A"); //2번 3번 실험에는 없애 버릴거임.
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Alpha0)) // 초기화 함수 
        {
            Debug.Log("Sending 0");
            serialController.SendSerialMessage("0");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // 가운데에서 부터 빨간색으로 변함 
        {
            Debug.Log("Sending 1"); //빨간불 켜졌다가 빡 
            serialController.SendSerialMessage("1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Sending 2");
            serialController.SendSerialMessage("2");// 점차 파란불로 점등 
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("Sending 7");
            serialController.SendSerialMessage("7");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Sending 8"); 
            serialController.SendSerialMessage("8");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Sending 21 빨간색불 ");
            serialController.SendSerialMessage("21");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Sending 22 오른쪽만 빨간 ");
            serialController.SendSerialMessage("22");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Sending 23 초록불");
            serialController.SendSerialMessage("23");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Sending 25 단속 걸릴때 불 ");
            serialController.SendSerialMessage("25");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Sending 26 단속 안걸릴때 불 ");
            serialController.SendSerialMessage("26");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6)) // 라이트 꺼버림 강종!!
        {
            Debug.Log("Sending 6");
            serialController.SendSerialMessage("6");
        }


        //if (rec.rgbButtons[2] == 128)
        //{
        //    serialController.SendSerialMessage("X");



        //    serialController.SendSerialMessage("C");

        //}
        //if (Input.GetKeyDown(KeyCode.X)) // 모터 강제 종료 장치 실수로 누리지 마셈
        //{
        //    serialController.SendSerialMessage("x");
        //}




        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        // else
        Debug.Log("Message arrived: " + message);
    }

    void OnTriggerEnter(Collider col)
    {
        
       

    }
}
