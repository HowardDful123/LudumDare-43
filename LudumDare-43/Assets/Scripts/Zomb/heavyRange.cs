using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyRange : MonoBehaviour {
    private Heavy parent;

    private void Start()
    {
        parent = GetComponentInParent<Heavy>();
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
