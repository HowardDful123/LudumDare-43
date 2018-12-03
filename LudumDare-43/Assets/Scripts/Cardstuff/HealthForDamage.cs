using UnityEngine.UI;
using UnityEngine;

public class HealthForDamage : MonoBehaviour {
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public int damagePowerup;
    public int healthToSacrifice;
    public Text effectSacrifice;
    public Text powerUpText;

    void Start()
    {
        healthToSacrifice = Random.Range(2,6);
        damagePowerup = Random.Range(3,11);
        powerUpText.text = "+" + damagePowerup.ToString() + " gun damage";
        effectSacrifice.text = "-" + healthToSacrifice.ToString() + " health for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("normalcard").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("normalcardMid").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("normalcardRight").transform;
        targetPlayer = GameObject.Find("Player").transform;
    }

    public void Sacrificehealthfordamage()
    {
        targetPlayer.SendMessage("TakeDamage", healthToSacrifice);
        targetPlayer.GetComponent<PlayerStat>().gunDamage += damagePowerup;

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
