using UnityEngine.UI;
using UnityEngine;

public class SwiftbutSquishy : MonoBehaviour {
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public int speedPowerup;
    public int healthToSacrifice;
    public Text effectSacrifice;
    public Text powerUpText;
    // Use this for initialization
    void Start () {
        healthToSacrifice = Random.Range(2, 4);
        speedPowerup = Random.Range(1, 3);  
        powerUpText.text = "+" + speedPowerup.ToString() + " Speed";
        effectSacrifice.text = "-" + healthToSacrifice.ToString() + " health for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("normalcard").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("normalcardMid").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("normalcardRight").transform;
        targetPlayer = GameObject.Find("Player").transform;
    }


    public void Sacrificehealthforspeed()
    {
        targetPlayer.GetComponent<PlayerStat>().currentHealth -= healthToSacrifice;
        targetPlayer.GetComponent<PlayerMovement>().moveSpeed += speedPowerup;

        DeleteCard();
    }

    void DeleteCard()
    {
        Destroy(gameObject);

        if (cardsStuffleft.childCount != 0)
        {
            foreach (Transform child in cardsStuffleft)
            {
                Destroy(child.gameObject);
            }
        }
        if (cardsStuffMiddle.childCount != 0)
        {
            foreach (Transform child in cardsStuffMiddle)
            {
                Destroy(child.gameObject);
            }
        }
        if (cardsStuffRight.childCount != 0)
        {
            foreach (Transform child in cardsStuffRight)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
