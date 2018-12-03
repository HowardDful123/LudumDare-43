using UnityEngine.UI;
using UnityEngine;

public class damageForHealth : MonoBehaviour {
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public int damageToSacrifice; 
    public int healthPowerup;
    public Text effectSacrifice;
    public Text powerUpText;

    void Start()
    {
        damageToSacrifice = Random.Range(1, 3);
        healthPowerup = Random.Range(5, 15);
        powerUpText.text = "+" + healthPowerup.ToString() + " Health";
        effectSacrifice.text = "-" + damageToSacrifice.ToString() + " Damage for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("normalcard").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("normalcardMid").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("normalcardRight").transform;
        targetPlayer = GameObject.Find("Player").transform;
    }

    public void Sacrificehealthfordamage()
    {
        if (targetPlayer.GetComponent<PlayerStat>().gunDamage - damageToSacrifice > 0)
        {
            targetPlayer.GetComponent<PlayerStat>().gunDamage -= damageToSacrifice;
        }
        targetPlayer.GetComponent<PlayerStat>().currentHealth += healthPowerup;
        targetPlayer.GetComponent<PlayerStat>().health += healthPowerup;
        targetPlayer.GetComponent<PlayerStat>().healthBar.fillAmount = targetPlayer.GetComponent<PlayerStat>().currentHealth / 
                                                                            targetPlayer.GetComponent<PlayerStat>().health;

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
