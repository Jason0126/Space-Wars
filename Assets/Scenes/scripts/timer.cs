using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    //�C���˼Ʈɶ�
    public int seconds = 120;
    //UI����
    public GameObject time;
    public GameObject result;
    public GameObject score_text;
    public GameObject result_text;
    //����
    int score;
    //�C�����A
    public bool game_pause = false;
    public string game_status = "Ready";

    void Start()
    {
        //��l��
        time.GetComponent<Text>().text = seconds.ToString();
        game_pause = false;
        game_status = "Ready";
        result.SetActive(false);
        //�ɶ��˼�
        StartCoroutine(countdown());
    }

    IEnumerator countdown()
    {
        //�C�����A����
        game_status = "Gaming";
        while (seconds > 0 && game_pause == false) 
        {
            //����1��
            yield return new WaitForSeconds(1);
            //����UI�ɶ�
            seconds--;
            time.GetComponent<Text>().text = seconds.ToString();
            score = Convert.ToInt32(GameObject.Find("score").GetComponent<Text>().text);
            print(score);
        }
        //�P�_�ɶ�
        if (seconds <= 0)
        {
            game_pause = true;
            game_status = "Win";
        }
        //�P�_�C�����A
        //����UI���G�W�C�����G����r
        if (game_status == "Win")
        {
            result_text.GetComponent<Text>().text = "Time Up";
        }
        else if (game_status == "Lose")
        {
            result_text.GetComponent<Text>().text = "Die";
        }
        //����UI���G�W���ƪ���r
        score_text.GetComponent<Text>().text = score.ToString(); 
        result.SetActive(true);
    }
}
