using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 5;

    private float lifetime = 0.3f;
    // Use this for initialization
    void Start()
    {
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

        if (nZombie != null)
        {
            nZombie.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (crawler != null)
        {
            crawler.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (heavy != null)
        {
            heavy.TakeDamage(damage);
            Destroy(gameObject);
        }
        Debug.Log(hitInfo.name);
        
    }
}
