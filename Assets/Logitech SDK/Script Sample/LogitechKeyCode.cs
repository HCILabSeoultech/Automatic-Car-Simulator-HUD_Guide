using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogitechKeyCode
{
    #region
    //FirstIndex 0 corresponds to the first game controller connected. SecondIndex 1 to the second game controller
    FirstIndex = 0,
    SecondIndex = 1,
    #endregion

    //FOR G29 INPUTS 
    #region
    Cross = 0,
    Square = 1,
    Circle = 2,
    Triangle = 3,
    #endregion

    #region
    //May be used for Gear without Shifter OR for Indicators
    RIGHTBUMPER = 4,
    LEFTBUMPER = 5,
    #endregion

    R2 = 6,
    L2 = 7,
    SHARE = 8,
    OPTION = 9,
    R3 = 10,
    L3 = 11,

    #region
    //Logitech Shifter for G29 
    Shifter1 = 12,
    Shifter2 = 13,
    Shifter3 = 14,
    Shifter4 = 15,
    Shifter5 = 16,
    Shifter6 = 17,
    Shifter7 = 18,
    #endregion

    #region
    //May be used for Volume
    LogiPlus = 19,
    LogiMinus = 20,
    #endregion

    #region
    //Combination of Red and Black Button
    RedClockWise = 21,
    RedAntiClockWise = 22,
    ArrowButton = 23,
    #endregion

    PSButton = 24,

    #region
    //Directional pad
    UPButton = 0,
    DOWNButton = 18000,
    LEFTButton = 27000,
    RIGHTButton = 9000,
    UP_LEFTButton = 31500,
    UP_RIGHTButton = 4500,
    DOWN_LEFT_BUTTON = 22500,
    DOWN_RIGHT_BUTTON = 13500
    #endregion

};

