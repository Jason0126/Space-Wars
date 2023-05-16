using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //子彈數據
    public GameObject bullet;
    public float bullet_speed = 0.5f;
    public float bullet_cd = 50f;
    //敵人數據
    public GameObject Enemy_a; //預設物件
    public float enemy_a_speed = 0.5f; //移動速度
    public float enemy_a_cd = 200f; //重生時間
    //玩家數據
    public int HP = 3;
    public float move_speed = 0.5f;
    public GameObject HP1; //血條第1顆心
    public GameObject HP2; //血條第2顆心
    public GameObject HP3; //血條第3顆心
    //飛機動畫判斷
    public bool center = true;
    public bool left = false;
    public bool right = false;

    void FixedUpdate()
    {
        //遊戲暫停判斷
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //角色移動
            player_move();
            //子彈射擊
            auto_shot();
            //敵人生成
            spawn_enemy();
            //判斷血量改變血條顯示
            //當 HP = 0 把 timer 的 game_status = "lose" 和 game_pause = true
            switch (HP)
            {
                case 2:
                    HP1.active = false;
                    break;
                case 1:
                    HP1.active = false;
                    HP2.active = false;
                    break;
                case 0:
                    HP1.active = false;
                    HP2.active = false;
                    HP3.active = false;
                    GameObject.Find("Time").GetComponent<timer>().game_status = "Lose";
                    GameObject.Find("Time").GetComponent<timer>().game_pause = true;
                    break;
            }
        }
    }

    void player_move()
    {
        //抓取玩家的 Animator
        Animator animator = this.gameObject.GetComponent<Animator>();
        //獲取玩家座標 X Y
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //按鍵按下判斷
        //左移和右移 會改變移動動畫
        if (Input.GetKey("a") && !right)
        {
            print("a");
            animator.SetBool("Is_left", true);
            center = false;
            left = true;
            x -= 0.01f * move_speed;
        }
        if (Input.GetKey("d") && !left)
        {
            print("d");
            animator.SetBool("Is_right", true);
            center = false;
            right = true;
            x += 0.01f * move_speed;
        }
        if (Input.GetKey("w"))
        {
            y += 0.01f * move_speed;
        }
        if (Input.GetKey("s"))
        {
            y -= 0.01f * move_speed;
        }
        //改變玩家位置
        this.gameObject.transform.position = new Vector3(x, y, 0);
        //按鍵放開判斷 改變移動動畫回 center
        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("Is_left", false);
            center = true;
            left = false;
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("Is_right", false);
            center = true;
            right = false;
        }
    }

    void auto_shot()
    {
        //獲取玩家位置
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //判斷子彈冷卻時間
        if (bullet_cd <= 0)
        {
            //生成子彈在玩家Y軸前方
            Instantiate(bullet, new Vector3(x, (y + 0.7f), 0), Quaternion.identity);
            bullet_cd = 50f;
        }
        else
        { 
            bullet_cd -= bullet_speed;
        }
    }

    void spawn_enemy()
    {
        //判斷生成敵人的冷卻時間
        if (enemy_a_cd <= 0)
        {
            //生成範圍
            float x1 = -1.75f;
            float x2 = 1.75f;
            //動態生成
            float x = Random.Range(x1, x2);
            Instantiate(Enemy_a, new Vector3(x, 6, 0), Quaternion.identity);
            enemy_a_cd = 200f;
        }
        else
        {
            enemy_a_cd -= enemy_a_speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //玩家碰撞敵人判斷
        if (collision.gameObject.tag == "enemy")
        {
            HP--;
        }
    }
}
