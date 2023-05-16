using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    //關閉遊戲
    public void quitgame()
    {
        print("quit");
        Application.Quit();
    }
    //載入demo場景
    public void load_demo_scene()
    {
        SceneManager.LoadScene("scene_game_demo");
    }
    //載入開始頁面場景
    public void back_to_start()
    {
        SceneManager.LoadScene("scene_start");
    }
}