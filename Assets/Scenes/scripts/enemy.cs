using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    //敵人數據
    public int hp;
    public float move_speed = 0.5f;

    void FixedUpdate()
    {
        //遊戲暫停判斷
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //敵人移動
            move();
            //血量判斷
            if (hp <= 0)
            {
                //銷毀敵人
                Destroy(this.gameObject);
                //分數增加
                GameObject score = GameObject.Find("score");
                score.GetComponent<Text>().text = (Convert.ToInt32(score.GetComponent<Text>().text) + 1).ToString();
            }
        }
    }

    void move()
    {
        //獲取敵人位置
        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y;
        //改變敵人Y軸座標
        y -= 0.01f*move_speed; 
        this.gameObject.transform.position = new Vector3(x,y,0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //敵人碰撞子彈判斷
        if (collision.gameObject.tag == "bullet")
        {
            //敵人血量 - 子彈傷害
            hp -= collision.gameObject.GetComponent<bullet>().damage;
        }
    }

}
