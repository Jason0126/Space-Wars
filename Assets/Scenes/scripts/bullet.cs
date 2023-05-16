using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //�l�u�ƾ�
    public int damage = 1;
    public float bullet_speed = 1f;

    void FixedUpdate()
    {
        //�C���Ȱ��P�_
        if (GameObject.Find("Time").GetComponent<timer>().game_pause == false)
        {
            //�l�u����
            move();
        }
    }

    void move()
    {
        //����l�u��m
        float x = this.gameObject.GetComponent<Transform>().position.x;
        float y = this.gameObject.GetComponent<Transform>().position.y;
        //���ܤl�uY�b��m
        y += 0.05f * bullet_speed;
        this.gameObject.transform.position = new Vector3(x, y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //�l�u������P�_
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�l�u�����ĤH�P�_
        Destroy(this.gameObject);
    }

}
