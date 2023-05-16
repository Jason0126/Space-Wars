using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    //遊戲倒數時間
    public int seconds = 120;
    //UI物件
    public GameObject time;
    public GameObject result;
    public GameObject score_text;
    public GameObject result_text;
    //分數
    int score;
    //遊戲狀態
    public bool game_pause = false;
    public string game_status = "Ready";

    void Start()
    {
        //初始化
        time.GetComponent<Text>().text = seconds.ToString();
        game_pause = false;
        game_status = "Ready";
        result.SetActive(false);
        //時間倒數
        StartCoroutine(countdown());
    }

    IEnumerator countdown()
    {
        //遊戲狀態改變
        game_status = "Gaming";
        while (seconds > 0 && game_pause == false) 
        {
            //等待1秒
            yield return new WaitForSeconds(1);
            //改變UI時間
            seconds--;
            time.GetComponent<Text>().text = seconds.ToString();
            score = Convert.ToInt32(GameObject.Find("score").GetComponent<Text>().text);
            print(score);
        }
        //判斷時間
        if (seconds <= 0)
        {
            game_pause = true;
            game_status = "Win";
        }
        //判斷遊戲狀態
        //改變UI結果上遊戲結果的文字
        if (game_status == "Win")
        {
            result_text.GetComponent<Text>().text = "Time Up";
        }
        else if (game_status == "Lose")
        {
            result_text.GetComponent<Text>().text = "Die";
        }
        //改變UI結果上分數的文字
        score_text.GetComponent<Text>().text = score.ToString(); 
        result.SetActive(true);
    }
}
