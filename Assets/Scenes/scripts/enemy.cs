using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    //�ĤH�ƾ�
    public int hp;
    public float move_speed = 0.5f;

    void FixedUpdate()
    {
        //�C���Ȱ��P�_
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //�ĤH����
            move();
            //��q�P�_
            if (hp <= 0)
            {
                //�P���ĤH
                Destroy(this.gameObject);
                //���ƼW�[
                GameObject score = GameObject.Find("score");
                score.GetComponent<Text>().text = (Convert.ToInt32(score.GetComponent<Text>().text) + 1).ToString();
            }
        }
    }

    void move()
    {
        //����ĤH��m
        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y;
        //���ܼĤHY�b�y��
        y -= 0.01f*move_speed; 
        this.gameObject.transform.position = new Vector3(x,y,0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�ĤH�I���l�u�P�_
        if (collision.gameObject.tag == "bullet")
        {
            //�ĤH��q - �l�u�ˮ`
            hp -= collision.gameObject.GetComponent<bullet>().damage;
        }
    }

}
