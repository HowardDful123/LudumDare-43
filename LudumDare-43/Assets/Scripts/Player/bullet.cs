using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;

    private Transform targetPlayer;
    private float lifetime = 0.7f;
    // Use this for initialization
    void Start()
    {
        targetPlayer = GameObject.Find("Player").transform;
        damage = targetPlayer.GetComponent<PlayerStat>().gunDamage;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        NZombie nZombie = hitInfo.GetComponent<NZombie>();
        Crawler crawler = hitInfo.GetComponent<Crawler>();
        Heavy heavy = hitInfo.GetComponent<Heavy>();

        if (hitInfo.tag == "Base")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (nZombie != null)
        {
            if (targetPlayer.GetComponent<Weapon>().IsLifeSteal)
            {
                if (targetPlayer.GetComponent<PlayerStat>().currentHealth < targetPlayer.GetComponent<PlayerStat>().health)
                {
                    targetPlayer.GetComponent<PlayerStat>().currentHealth += damage;
                    targetPlayer.GetComponent<PlayerStat>().healthBar.fillAmount = targetPlayer.GetComponent<PlayerStat>().currentHealth /
                                                                            targetPlayer.GetComponent<PlayerStat>().health;
                    if (targetPlayer.GetComponent<PlayerStat>().currentHealth >= targetPlayer.GetComponent<PlayerStat>().health)
                    {
                        targetPlayer.GetComponent<PlayerStat>().currentHealth = targetPlayer.GetComponent<PlayerStat>().health;
                    }
                }
            }
            nZombie.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (crawler != null)
        {
            if (targetPlayer.GetComponent<Weapon>().IsLifeSteal)
            {
                if (targetPlayer.GetComponent<PlayerStat>().currentHealth < targetPlayer.GetComponent<PlayerStat>().health)
                {
                    targetPlayer.GetComponent<PlayerStat>().currentHealth += damage;
                    if (targetPlayer.GetComponent<PlayerStat>().currentHealth >= targetPlayer.GetComponent<PlayerStat>().health)
                    {
                        targetPlayer.GetComponent<PlayerStat>().currentHealth = targetPlayer.GetComponent<PlayerStat>().health;
                    }
                }
            }
            crawler.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (heavy != null)
        {
            if (targetPlayer.GetComponent<Weapon>().IsLifeSteal)
            {
                if (targetPlayer.GetComponent<PlayerStat>().currentHealth < targetPlayer.GetComponent<PlayerStat>().health)
                {
                    targetPlayer.GetComponent<PlayerStat>().currentHealth += damage;
                    if (targetPlayer.GetComponent<PlayerStat>().currentHealth >= targetPlayer.GetComponent<PlayerStat>().health)
                    {
                        targetPlayer.GetComponent<PlayerStat>().currentHealth = targetPlayer.GetComponent<PlayerStat>().health;
                    }
                }
            }
            heavy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        Debug.Log(hitInfo.name);
        
    }
}
