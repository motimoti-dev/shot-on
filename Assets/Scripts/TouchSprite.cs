using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using MyPictManage;

public class TouchSprite : MonoBehaviour
{

    static Image mine;
    static Sprite sprite;
    public static Sprite returnSprite;
    GameObject clickedGameObject;
    public PictManage pm;
    private void Awake()
    {
        
    }
    void Start()
    {
        //Invoke("LaunchProjectile", 1.0f);

        pm = GameObject.Find("SendPicture").GetComponent<PictManage>();
    }
    /*
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            //指定の位置から発射されるRayを作成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Rayとオブジェクトの接触を調べる
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            //接触してたらオブジェクトを小さくする
            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                hit2d.transform.localScale = smlSize;
            }

            Debug.Log(clickedGameObject);
        }
    }*/
    
    public void sendPicture01()
    {
        clickedGameObject = GameObject.Find("ANIMEImage(1)");
        mine = clickedGameObject.GetComponent<Image>();
        Debug.Log(mine.sprite);
        pm.SpManage = mine.sprite;

        if (mine.sprite != null)
            SceneManager.LoadScene("RawCamera");
    }
    public void sendPicture02()
    {
        clickedGameObject = GameObject.Find("ANIMEImage(2)");
        mine = clickedGameObject.GetComponent<Image>();
        pm.SpManage = mine.sprite;

        if (mine.sprite != null)
            SceneManager.LoadScene("RawCamera");
    }
    public void sendPicture03()
    {
        clickedGameObject = GameObject.Find("ANIMEImage(3)");
        mine = clickedGameObject.GetComponent<Image>();
        pm.SpManage = mine.sprite;

        if (mine.sprite != null)
            SceneManager.LoadScene("RawCamera");
    }
    public void sendPicture04()
    {
        clickedGameObject = GameObject.Find("ANIMEImage(4)");
        mine = clickedGameObject.GetComponent<Image>();
        pm.SpManage = mine.sprite;

        if (mine.sprite != null)
            SceneManager.LoadScene("RawCamera");
    }
    public void sendPicture05()
    {
        clickedGameObject = GameObject.Find("ANIMEImage(5)");
        mine = clickedGameObject.GetComponent<Image>();
        pm.SpManage = mine.sprite;

        if (mine.sprite != null)
            SceneManager.LoadScene("RawCamera");
    }
    
}
