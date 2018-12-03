using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realoadingbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
        
    }
}
