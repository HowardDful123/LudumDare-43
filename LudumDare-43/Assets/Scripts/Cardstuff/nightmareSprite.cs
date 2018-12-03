using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightmareSprite : MonoBehaviour {
    public GameObject[] cards;


    public void SpawnLeftCard(string tag)
    {
        GameObject newCard = Instantiate(cards[0], transform.position, transform.rotation) as GameObject;
        newCard.transform.parent = GameObject.FindGameObjectWithTag(tag).transform;

    }
    public void SpawnMiddleCard(string tag)
    {
        GameObject newCard = Instantiate(cards[1], transform.position, transform.rotation) as GameObject;
        newCard.transform.parent = GameObject.FindGameObjectWithTag(tag).transform;

    }
    public void SpawnRightCard(string tag)
    {
        GameObject newCard = Instantiate(cards[2], transform.position, transform.rotation) as GameObject;
        newCard.transform.parent = GameObject.FindGameObjectWithTag(tag).transform;

    }
}
