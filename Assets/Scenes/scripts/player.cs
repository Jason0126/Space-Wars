using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //�l�u�ƾ�
    public GameObject bullet;
    public float bullet_speed = 0.5f;
    public float bullet_cd = 50f;
    //�ĤH�ƾ�
    public GameObject Enemy_a; //�w�]����
    public float enemy_a_speed = 0.5f; //���ʳt��
    public float enemy_a_cd = 200f; //���ͮɶ�
    //���a�ƾ�
    public int HP = 3;
    public float move_speed = 0.5f;
    public GameObject HP1; //�����1����
    public GameObject HP2; //�����2����
    public GameObject HP3; //�����3����
    //�����ʵe�P�_
    public bool center = true;
    public bool left = false;
    public bool right = false;

    void FixedUpdate()
    {
        //�C���Ȱ��P�_
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //���Ⲿ��
            player_move();
            //�l�u�g��
            auto_shot();
            //�ĤH�ͦ�
            spawn_enemy();
            //�P�_��q���ܦ�����
            //�� HP = 0 �� timer �� game_status = "lose" �M game_pause = true
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
        //������a�� Animator
        Animator animator = this.gameObject.GetComponent<Animator>();
        //������a�y�� X Y
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //������U�P�_
        //�����M�k�� �|���ܲ��ʰʵe
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
        //���ܪ��a��m
        this.gameObject.transform.position = new Vector3(x, y, 0);
        //�����}�P�_ ���ܲ��ʰʵe�^ center
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
        //������a��m
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //�P�_�l�u�N�o�ɶ�
        if (bullet_cd <= 0)
        {
            //�ͦ��l�u�b���aY�b�e��
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
        //�P�_�ͦ��ĤH���N�o�ɶ�
        if (enemy_a_cd <= 0)
        {
            //�ͦ��d��
            float x1 = -1.75f;
            float x2 = 1.75f;
            //�ʺA�ͦ�
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
        //���a�I���ĤH�P�_
        if (collision.gameObject.tag == "enemy")
        {
            HP--;
        }
    }
}
