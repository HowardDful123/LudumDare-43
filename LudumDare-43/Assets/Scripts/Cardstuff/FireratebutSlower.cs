using UnityEngine.UI;
using UnityEngine;

public class FireratebutSlower : MonoBehaviour {
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public float fireratePowerup;
    public float movespeedSacrifice;
    public Text effectSacrifice;
    public Text powerUpText;
    // Use this for initialization
    void Start()
    {
        movespeedSacrifice = Random.Range(0.5f, 1f);
        fireratePowerup = Random.Range(0.15f, 0.4f);
        powerUpText.text = "+" + fireratePowerup.ToString("F2") + " Firerate";
        effectSacrifice.text = "-" + movespeedSacrifice.ToString("F") + " Movespeed for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("normalcard").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("normalcardMid").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("normalcardRight").transform;
        targetPlayer = GameObject.Find("Player").transform;
    }

    public void Sacrificehealthforspeed()
    {
        targetPlayer.GetComponent<PlayerMovement>().moveSpeed -= movespeedSacrifice;
        targetPlayer.GetComponent<Weapon>().fireRate -= fireratePowerup;
        if (targetPlayer.GetComponent<PlayerMovement>().moveSpeed <= 0)
        {
            targetPlayer.GetComponent<PlayerMovement>().moveSpeed = 1f/movespeedSacrifice;
        }
        if (targetPlayer.GetComponent<Weapon>().fireRate <= 0)
        {
            targetPlayer.GetComponent<Weapon>().fireRate = 0.1f;
        }

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
