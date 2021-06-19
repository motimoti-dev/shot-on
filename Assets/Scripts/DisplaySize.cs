using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySize : MonoBehaviour {
    static int width, height;
    private static int priWidth = 1080, priHeight = 1920;
    static double scaleWidth, scaleHeight;
    void Awake () {
        width = Screen.currentResolution.width;
        height = Screen.currentResolution.height;
        scaleWidth = width / (double)priWidth;
        scaleHeight = height / (double)priHeight;
    }
    void Start()
    {
        Debug.Log(width+","+height);
        
    }
    static public int ReturnScreenSizeWidth()
    {
        return width;
    }

    static public int ReturnScreenSizeHeight()
    {
        return height;
    }

    static public double ReturnScaleWidth()
    {
        return scaleWidth;
    }
    static public double ReturnScaleHeight()
    {
        return scaleHeight;
    }
}
