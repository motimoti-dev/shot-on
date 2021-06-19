using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictSelectC : MonoBehaviour
{
    static int s = 0;
    float DisWHalf, DisHHalf, posY;
    double sclW, sclH;
    //CallPrefab.csにも追加
    string[] AnimeName =
    {
        "まちカドまぞく","恋する小惑星","わたしに天使が舞い降りた！"
    };
    [SerializeField]
    GameObject ButtonsPrefab;
    Button[] animetitle;
    GameObject[] Buttons;
    Text[] name;
    bool flag;

    void Awake()
    {
        DisWHalf = DisplaySize.ReturnScreenSizeWidth() / 2.0f;
        DisHHalf = DisplaySize.ReturnScreenSizeHeight() / 2.0f;
        sclW = DisplaySize.ReturnScaleWidth();
        sclH = DisplaySize.ReturnScaleHeight();

    }
    void Start()
    {
        ButtonsPrefab.GetComponent<Button>();
        s = AnimeName.Length + 1;
        Buttons = new GameObject[s];
        animetitle = new Button[s];
        name = new Text[s];
        ButtonSet();
        flag = false;
        Debug.Log(DisWHalf + "," + DisHHalf);
    }

    void Update()
    {
        if (flag)
        {
            destroyButtons();
        }
    }

    void ButtonSet()
    {
        posY = (DisHHalf * 2) - (DisHHalf / 6);
        for (int i = 0; i < s - 1; i++)
        {
            //配列の回数分prefabの生成
            Buttons[i] = Instantiate(ButtonsPrefab, new Vector2(DisWHalf, posY), Quaternion.identity, this.transform);
            //ボタンprefabの名前変更
            Buttons[i].name = AnimeName[i];
            animetitle[i] = GameObject.Find(AnimeName[i]).GetComponent<Button>();
            //ボタンの子オブジェクトを取得後UI.Textのコンポーネントを取得
            name[i] = Buttons[i].transform.GetChild(0).gameObject.GetComponent<Text>();
            //ボタンのテキストをアニメタイトルに変更
            name[i].text = AnimeName[i];
            //次に表示するボタンの位置設定
            posY -= ((DisHHalf / 6) + 20) * (float)sclH;
        }
        //もどるボタンの表示
        Buttons[s - 1] = Instantiate(ButtonsPrefab, new Vector2(DisWHalf, posY), Quaternion.identity, this.transform);
        Buttons[s - 1].name = "Back";
        animetitle[s - 1] = GameObject.Find("Back").GetComponent<Button>();
        name[s - 1] = Buttons[s - 1].transform.GetChild(0).gameObject.GetComponent<Text>();
        name[s - 1].text = "もどる";
        
    }
    
    public void destroyButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            //Destroy(Buttons[i],2);
            Buttons[i].SetActive(false);
        }
    }
    public void SetActive()
    {
        flag = true;
    }
}
