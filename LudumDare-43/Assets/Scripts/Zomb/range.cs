using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour {
    private NZombie parent;

    private void Start()
    {
        parent = GetComponentInParent<NZombie>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.PlayerTarget = collision.transform;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.PlayerTarget = null;
        }
        
    }
}
