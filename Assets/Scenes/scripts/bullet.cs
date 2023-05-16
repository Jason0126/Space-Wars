using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //子彈數據
    public int damage = 1;
    public float bullet_speed = 1f;

    void FixedUpdate()
    {
        //遊戲暫停判斷
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //子彈移動
            move();
        }
    }

    void move()
    {
        //獲取子彈位置
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //改變子彈Y軸位置
        y += 0.05f * bullet_speed;
        this.gameObject.transform.position = new Vector3(x, y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //子彈消除牆判斷
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //子彈擊中敵人判斷
        Destroy(this.gameObject);
    }

}
