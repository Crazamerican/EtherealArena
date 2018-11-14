﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder: MonoBehaviour
{


    private const float baseSpeed = 10f;
    private float speed;
    private float angle;
    private float spinAnimationTimer = 0f;
    private float aimingAnimationTimer = 0f;
    private Quaternion aimedDirection;
    private Transform target;
    private float timeCounter;
    private float width;
    private float height;
    private float moveSpeed;
    private Vector3 centerPoint;
    private Vector3 tar;
    private float timer;
    private int attack;

    private readonly int ATK_1 = 1;
    private readonly int ATK_2 = 2;

    void reset()
    {
        speed = baseSpeed;
    }

    private void OnEnable()
    {
        speed = baseSpeed;
    }

    void Start()
    {
        timeCounter = 0;
        speed = 10;
        width = 1;
        height = 1;
        centerPoint = transform.position;
        timer = Time.time + 2f;
    }

    void Update()
    {
        gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.layer != 8)
            {
                PlayerStatus playerStatus = other.gameObject.GetComponent<PlayerStatus>();
                if (playerStatus != null)
                {
                    playerStatus.TakeHit();
                }
                else
                {
                    Debug.LogError("No player status script found.");
                }
                speed = 0f;
                gameObject.SetActive(false);
            }
        }
    }

    public void setTarget(Vector3 target)
    {
        tar = Vector3.Normalize(target);

    }

    public void setSpeed(int s)
    {
        moveSpeed = s;
    }

    public void setTimer(int t)
    {
        timer = Time.time + t;
    }

    private void Attack1()
    {
        timeCounter += Time.deltaTime * speed;
        centerPoint += tar * moveSpeed * Time.deltaTime;
        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        transform.position = new Vector3(x + centerPoint.x, y + centerPoint.y, 0f);
    }

    private void Attack2()
    {
        transform.position = transform.position + tar;
    }

    public void setAttackOne()
    {
        attack = ATK_1;
        //Debug.Log("set attack 1");
    }

    public void setAttackTwo()
    {
        attack = ATK_2;
    }
}
