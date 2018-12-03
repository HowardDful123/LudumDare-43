using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalSprite : MonoBehaviour {

    public GameObject[] cards;


    public void SpawnCard(string tag)
    {
        GameObject newCard = Instantiate(cards[Random.Range(0, cards.Length)], transform.position, transform.rotation) as GameObject;
        newCard.transform.parent = GameObject.FindGameObjectWithTag(tag).transform;

    }
}
