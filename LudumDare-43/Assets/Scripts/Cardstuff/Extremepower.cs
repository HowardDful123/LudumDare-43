using UnityEngine.UI;
using UnityEngine;

public class Extremepower : MonoBehaviour {
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public float firerateToSacrifice;
    public int healthToSacrifice;
    public float movespeedSacrifice;
    public int damagePowerup;
    public Text effectSacrifice;
    public Text powerUpText;
    // Use this for initialization
    void Start () {
        healthToSacrifice = Random.Range(5, 11);
        movespeedSacrifice = Random.Range(0.2f, 0.8f);
        firerateToSacrifice = Random.Range(0.1f, 0.3f);
        damagePowerup = Random.Range(30, 51);
        powerUpText.text = "+" + damagePowerup.ToString() + " Damage";
        effectSacrifice.text = "-" + healthToSacrifice.ToString() + " health, -" 
                                + movespeedSacrifice.ToString("F2") + " speed, -" + firerateToSacrifice.ToString("F2")
                                + " firerate" + " for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("nightmarecardL").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("nightmarecardM").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("nightmarecardR").transform;
        targetPlayer = GameObject.Find("Player").transform;
    }

    public void SacrificePowerExtreme()
    {
        targetPlayer.SendMessage("TakeDamage", healthToSacrifice);
        targetPlayer.GetComponent<PlayerMovement>().moveSpeed -= movespeedSacrifice;
        targetPlayer.GetComponent<Weapon>().fireRate += firerateToSacrifice;
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
