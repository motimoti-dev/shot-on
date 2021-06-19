using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanage : MonoBehaviour {

    [SerializeField]
    GameObject home, pict;
    [SerializeField]
    Text h1, h2;
    int DisW, DisH;
    double sclW, sclH;
    private void Awake()
    {
        DisW = DisplaySize.ReturnScreenSizeWidth();
        DisH = DisplaySize.ReturnScreenSizeHeight();
        sclW = DisplaySize.ReturnScaleWidth();
        sclH = DisplaySize.ReturnScaleHeight();
    }
    void Start () {
        home.transform.localPosition = new Vector2(0, -DisH * 3 / 12);
        pict.transform.localPosition = new Vector2(0, 0);
        home.transform.localScale = new Vector2((float)sclW, (float)sclH);
        pict.transform.localScale = new Vector3((float)sclW, (float)sclH, 1);
        Debug.Log(sclW+", "+sclH);
        h1.fontSize = h2.fontSize = (int)(70 * sclH);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
