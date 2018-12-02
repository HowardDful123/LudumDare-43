using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour {

    public int health = 200;
    public Transform baseTarget;
    public float attackRange;
    public int damage = 20;
    public float attackDelay = 1;

    private float timeElapsedColor;
    private bool isColorChanged;
    private float lastAttack;
    private float speed = 2f;
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
        baseTarget = GameObject.Find("Base").GetComponent<Transform>();
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

        if (health <= 0) Die();
    }

    private void FollowBase()
    {
        if (PlayerTarget == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, baseTarget.position, speed * Time.deltaTime);
        }
    }

    private void FollowPlayer()
    {
        if (PlayerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTarget.position, speed * Time.deltaTime);
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
        sr.color = new Color(0f, 0.02083302f, 1f, 1f);
    }
}
