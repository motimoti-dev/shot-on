using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackC : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Home) || Input.GetKeyUp(KeyCode.Menu))
        {
            NextScene();
        }
    }
    public void NextScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Home":
                {
                    AndroidHome();
                    break;
                }

            case "PictureSelrct":
                {
                    AppHome();
                    break;
                }

            case "RawCamera":
                {
                    PictureSelrct();
                    break;
                }

            default:
                {
                    Debug.LogError("読み込むシーンが未設定です。");
                    break;
                }
        }
    }
    public void AndroidHome()
    {
        Application.Quit();
        return;
    }
    public void AppHome()
    {
        SceneManager.LoadScene("Home");
        return;
    }
    public void PictureSelrct()
    {
        SceneManager.LoadScene("PictureSelrct");
        return;
    }
}
