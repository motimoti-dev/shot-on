using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimesPictures : MonoBehaviour
{
    int sheets, pages;
    bool pageCheck;
    [SerializeField]
    private GameObject UpBTN,DownBTN;
    [SerializeField]
    Image[] pict = new Image[6];
    [Header("作品ごとの写真の枚数")]
    [SerializeField]
    Sprite[] Sprites;
    //Texture BackBTN;
    /// <summary>
    /// もし写真バックが押されたらシーンのリロード
    /// </summary>
    // Start is called before the first frame update
    void Awake()
    {

        pages = 0;

        pageCheck = false;
        //アニメ画像の枚数取得
        sheets = Sprites.Length;

        //Textures = new Texture[sheets];

        setImages();
    }

    // Update is called once per frame
    void Update()
    {
        if(pages <= 0)
            UpBTN.SetActive(false);
        else
            UpBTN.SetActive(true);

        if (pageCheck)
            DownBTN.SetActive(false);
        else
            DownBTN.SetActive(true);

    }
    void setImages()
    {
        //pict[0].material.mainTexture = BackBTNで固定

        for(int i = 0; i < 5; i++)
        {
            if (i + (5 * pages) < Sprites.Length)
            {
                pict[i + 1].sprite = Sprites[i + (5 * pages)];
                pageCheck = false;
                    if(i + (5 * pages) == Sprites.Length - 1)
                        pageCheck = true;
            }

            //
            else
            {
                pict[i + 1].sprite = null;
                pageCheck = true;
                continue;
            }
        }

        /*
        pict[1].sprite = Sprites[0 + (5 * pages)];

        pict[2].sprite = Sprites[1 + (5 * pages)];

        pict[3].sprite = Sprites[2 + (5 * pages)];

        pict[4].sprite = Sprites[3 + (5 * pages)];

        pict[5].sprite = Sprites[4 + (5 * pages)];
        */

    }

    //イメージのレイアウトの設定
    /*void setLayout()
    {
        pict[0].transform.
    }*/
    public void upBTN()
    {
        

        pages--;

        setImages();
    }

    public void downBTN()
    {
        pages++;

        setImages();
    }
}
