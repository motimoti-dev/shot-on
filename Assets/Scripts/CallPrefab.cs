using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallPrefab : MonoBehaviour
{
    GameObject PictsPrefab, obj;
    public GameObject[] AnimesPrefabs;
    float DisWHalf, DisHHalf;
    public PictSelectC psc;

    // Start is called before the first frame update
    void Awake()
    {
        DisWHalf = DisplaySize.ReturnScreenSizeWidth() / 2.0f;
        DisHHalf = DisplaySize.ReturnScreenSizeHeight() / 2.0f;

    }
    void Start()
    {
        psc = GameObject.Find("Canvas").GetComponent<PictSelectC>();
        Debug.Log(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallPicturePrefab()
    {
        Divide();
        Debug.Log(PictsPrefab);
        obj = Instantiate(PictsPrefab, new Vector2(DisWHalf, DisHHalf), Quaternion.identity, this.transform);
        obj.transform.parent = GameObject.Find("Canvas").transform;
        psc.SetActive();
    }
    void Divide()
    {
        switch (this.gameObject.name)
        {
            case "まちカドまぞく":
                {
                    PictsPrefab = AnimesPrefabs[0];
                    break;
                }

            case "恋する小惑星":
                {
                    PictsPrefab = AnimesPrefabs[1];
                    break;
                }

            case "わたしに天使が舞い降りた！":
                {
                    PictsPrefab = AnimesPrefabs[2];
                    break;
                }

            case "Back":
                {
                    SceneManager.LoadScene("Home");
                    break;
                }

            default:
                {
                    Debug.LogError("アニメ名とプレファブを追加し忘れています。");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }
        }
    }
}
