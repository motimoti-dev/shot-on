using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MyPictManage;

public class GetImageSprite : MonoBehaviour
{
    GameObject gm;
    Image image;
    public Sprite sprite;
    PictManage pm;

    RectTransform r;
    float trance;
    int DisW, DisH;
    // Start is called before the first frame update
    private void Awake()
    {
        pm = GameObject.Find("SendPicture").GetComponent<PictManage>();

        DisW = DisplaySize.ReturnScreenSizeWidth();
        DisH = DisplaySize.ReturnScreenSizeHeight();
    }
    void Start()
    {
        gm = this.gameObject;
        image = gm.GetComponent<Image>();
        r = gm.GetComponent<RectTransform>();
        image.sprite = pm.SpManage;
        //Debug.Log(image.sprite);
        Display();
    }
    
    void Display()
    {
        //画像透過度
        image.color = new Color32(255, 255, 255, 51);
        //画像サイズを取得
        image.SetNativeSize();
        //横長画像は画像を回転
        if (r.sizeDelta.x > r.sizeDelta.y)
        {
            gm.transform.rotation = Quaternion.Euler(0, 0, 270.0f);

            SetImageSize(r.sizeDelta.x, r.sizeDelta.y, DisH, DisW);
        }
        else
        {
            SetImageSize(r.sizeDelta.x, r.sizeDelta.y, DisW, DisH);
        }

    }
    //画像サイズ変更
    void SetImageSize(float x, float y, int dx, int dy)
    {
        //画像倍率と画素数を比較。小さいほうをとる。
        float scale = (dx / x < dy / y) ? dx / x : dy / y;

        var DeltaSize = new Vector2(x * scale, y * scale);
        r.sizeDelta = DeltaSize;
    }
}
