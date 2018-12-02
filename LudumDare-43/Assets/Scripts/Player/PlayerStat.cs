using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {
    public int health = 50;
	
	
	// Update is called once per frame
	void Update () {
		
	}

    void TakeDamage(int damage)
    {
        health -= damage;
    }
}
