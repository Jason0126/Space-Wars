using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    //�����C��
    public void quitgame()
    {
        print("quit");
        Application.Quit();
    }
    //���Jdemo����
    public void load_demo_scene()
    {
        SceneManager.LoadScene("scene_game_demo");
    }
    //���J�}�l��������
    public void back_to_start()
    {
        SceneManager.LoadScene("scene_start");
    }
}