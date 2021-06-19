using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageC : MonoBehaviour
{
    [SerializeField]
    RawImage rawImage;

    WebCamTexture webCamTexture;

    const int index = 0;

    //bool Portrait = false;

    float ScaleW = DisplaySize.ReturnScreenSizeWidth(), ScaleH = DisplaySize.ReturnScreenSizeHeight();

    void Awake()
    {
        ScaleW *= .01f;
        ScaleH *= .01f;
        rawImage.transform.localScale = new Vector3(-ScaleH, ScaleW);
    }
    private IEnumerator Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogFormat("カメラのデバイスが無い様だ。撮影は諦めよう。");
            yield break;
        }

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.LogFormat("カメラを使うことが許可されていないようだ。市役所に届けでてくれ！");
            yield break;
        }

        // とりあえず最初に取得されたデバイスを使ってテクスチャを作りますよ。
        //constとは、変数の値を変更せず定数として宣言する際に使う修飾子 覚えよう!!
        WebCamDevice userCameraDevice = WebCamTexture.devices[index];
        webCamTexture = new WebCamTexture(userCameraDevice.name, Screen.currentResolution.height, Screen.currentResolution.width);
        //webCamTexture = new WebCamTexture(userCameraDevice.name, 1920, 1080);

        rawImage.texture = webCamTexture;

        // さあ、撮影開始だ！
        webCamTexture.Play();

    }
    /*void Start()
    {
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
    }*/

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            //Portrait = true;
            //rawImage.transform.localScale = new Vector3(ScaleH, -ScaleW);
            //rawImage.transform.localScale = new Vector3(19.2f, -10.8f);
            rawImage.transform.localScale = RawImageSize(Screen.width, Screen.height);
            //rawImage.transform.localScale = new Vector3(webCamTexture.height, -webCamTexture.width);
            //rawImage.transform.localScale = new Vector3(webCamTexture.requestedHeight, -webCamTexture.requestedWidth);
            //rawImage.transform.localScale = RawImageSize(ScaleH, ScaleW, webCamTexture.requestedHeight, webCamTexture.requestedWidth);

            RectTransform rectTrans = rawImage.gameObject.GetComponent<RectTransform>();

            // 向き調整
            Vector3 angles = rectTrans.eulerAngles;
            angles.y = WebCamTexture.devices[index].isFrontFacing ? 0 : 180;
            angles.z = -webCamTexture.videoRotationAngle;
            rectTrans.eulerAngles = angles;

        }
        else
        {
            //Portrait = false;
            rawImage.transform.localScale = new Vector3(ScaleH, -ScaleW);


            RectTransform rectTrans = rawImage.gameObject.GetComponent<RectTransform>();

            // 向き調整
            Vector3 angles = rectTrans.eulerAngles;
            angles.y = WebCamTexture.devices[index].isFrontFacing ? 90 : 270;
            angles.z = webCamTexture.videoRotationAngle;
            rectTrans.eulerAngles = angles;

        }
    }
    Vector3 RawImageSize(float x, float y)
    {
        int camX = 9, camY = 16;
        float camXsize, camYsize;
        float asp = x / camX;
        camXsize = asp * 0.01f * camX;
        camYsize = asp * 0.01f * camY;
        
        return new Vector3(camYsize, -camXsize);
    }
}
