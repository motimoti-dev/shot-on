using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadImage : MonoBehaviour
{
    [SerializeField]
    Image m_image = null;
    [SerializeField]
    Button abs;
    const string _FILE_HEADER = "file://";
    //シーン読み込み部
    private bool loading = false;
    private AsyncOperation async;
    string scenes;

    void Start()
    {
        //abs = false;
        loading = false;
    }
    void Update()
    {
        /*if (abs && !a) {
            a = true;
            Debug.Log("pushed");
            StartCoroutine("LoadImages");
        }*/
    }

    private IEnumerator LoadImages(string path)
    {
        Debug.Log("Coroutine");
        // ファイルが無かったらやめる
        if (!System.IO.File.Exists(path))
        {
            Debug.Log("File does NOT exist!!, path = " + path);
            yield break;
        }

        // ファイル読み込み
        WWW request = new WWW(_FILE_HEADER + path);

        // 読み込み待ち
        while (!request.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        // 画像を取り出す
        Texture2D texture = request.texture;

        // 読み込んだ画像からSpriteを作成する
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // 画像をUI Imageに設定する
        m_image.sprite = sprite;
        yield return 0;
    }
    public void button()
    {
        scenes = NextScene();
        Debug.Log(scenes);
        StartCoroutine(LoadScene());

    }
    public IEnumerator LoadScene()
    {
        if (!loading)
        {
            loading = !loading;
            //LoadSceneAsync にタイトル(string型)を入力すろ必要有。
            async = SceneManager.LoadSceneAsync(scenes);
            async.allowSceneActivation = false;
     
            while (async.isDone == false)
            {
                ///per=async.progress;
                if (async.progress == 0.9f)
                {
                    async.allowSceneActivation = true;
                }
                yield return null;//帰りたい
            }
        }
    }

    //次に開きたいシーン名を返す
    public string NextScene()
    {
        string sceneName = null;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Home":
                {
                    sceneName = "PictureSelrct";
                    break;
                }

            case "PictureSelrct":
                {
                    //仮置き
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }

            default:
                {
                    Debug.LogError("読み込むシーンが未設定です。");
                    break;
                }
        }
        return sceneName;
    }
}
