using System.Collections;


public class LogitechInput
{
    static LogitechGSDK.DIJOYSTATE2ENGINES rec;
    #region
    //Steering = Steering Horizontal , GasInput / Accelerator = Gas Vertical, ClutchInput = Clutch Vertical and BrakeInput = Brake Vertical

    public static float GetAxis(string axisName)
    {
        rec = LogitechGSDK.LogiGetStateUnity(0);
        switch (axisName)
        {
            case "Steering Horizontal": return rec.lX / 32760f;
            case "Gas Vertical": return ((rec.lY / -32760f + 1) / 2);
            case "Clutch Vertical": return rec.rglSlider[0] / -32760f;
            case "Brake Vertical": return ((rec.lRz / -32760f + 1) / 2);

        }
        return 0f;
    }
    #endregion

    public static bool GetKeyTriggered(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode)
    {
        if (LogitechGSDK.LogiButtonTriggered((int)gamecontroller, (int)keyCode))
        {
            return true;
        }
        return false;
    }

    public static bool GetKeyPressed(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode)
    {
        if (LogitechGSDK.LogiButtonIsPressed((int)gamecontroller, (int)keyCode))
        {
            return true;
        }
        return false;
    }

    public static bool GetKeyReleased(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode)
    {
        if (LogitechGSDK.LogiButtonReleased((int)gamecontroller, (int)keyCode))
        {
            return true;
        }
        return false;
    }

    public static uint GetKeyDirectional()
    {
        return rec.rgdwPOV[0];
    }
}
