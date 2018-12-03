﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour {

    public int health = 20;
    public Transform baseTarget;
    public float attackRange;
    public int damage = 3;
    public float attackDelay = 1;

    private float timeElapsedColor;
    private bool isColorChanged;
    private float lastAttack;
    private float speed = 3f;
    private Transform playerTarget;

    public Transform PlayerTarget
    {
        get
        {
            return playerTarget;
        }

        set
        {
            playerTarget = value;
        }
    }

    private void Start()
    {
        baseTarget = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
    }

    void Update()
    {
        if (PlayerTarget != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerTarget.position);
            if (distanceToPlayer < attackRange)
            {
                if (Time.time > lastAttack + attackDelay)
                {
                    PlayerTarget.SendMessage("TakeDamage", damage);
                    lastAttack = Time.time;
                }
            }
        }
        if (baseTarget != null)
        {
            float distanceToBase = Vector3.Distance(transform.position, baseTarget.position);
            if (distanceToBase < attackRange)
            {
                if (Time.time > lastAttack + attackDelay)
                {
                    baseTarget.SendMessage("Damagetobase", damage);
                    lastAttack = Time.time;
                }
            }
        }

        if (isColorChanged)
        {
            timeElapsedColor += Time.deltaTime;
            if (timeElapsedColor >= .25f)
            {
                timeElapsedColor = 0;
                isColorChanged = false;
                ResetColor();
            }
        }


        FollowPlayer();
        FollowBase();
    }




    public void TakeDamage(int damage)
    {
        health -= damage;
        ChangeColor();
        if (health <= 0) Die();
    }

    private void FollowBase()
    {
        if (PlayerTarget == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, baseTarget.position, speed * Time.deltaTime);
            Vector2 direction = new Vector2(
            baseTarget.position.x - transform.position.x,
            baseTarget.position.y - transform.position.y
            );
            transform.up = direction;
        }
    }

    private void FollowPlayer()
    {
        if (PlayerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTarget.position, speed * Time.deltaTime);
            Vector2 direction = new Vector2(
            playerTarget.position.x - transform.position.x,
            playerTarget.position.y - transform.position.y
            );
            transform.up = direction;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(0f, 1f, 0.1581101f, 1f);
    }

}
