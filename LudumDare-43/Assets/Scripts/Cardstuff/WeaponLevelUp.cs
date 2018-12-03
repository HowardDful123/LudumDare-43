using UnityEngine.UI;
using UnityEngine;

public class WeaponLevelUp : MonoBehaviour {
    private Transform targetBase;
    private Transform targetPlayer;
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;

    public float baseHealthTosacrifice;
    public Text effectSacrifice;
    public Text powerUpText;
    // Use this for initialization
    void Start () {
        targetBase = GameObject.Find("Base").transform;
        targetPlayer = GameObject.Find("Player").transform;
        baseHealthTosacrifice = Random.Range(500,1001);
        if (targetPlayer.GetComponent<Weapon>().weaponLevel < 3)
        {
            powerUpText.text = "Weapon Upgrade";
        }
        else
        {
            powerUpText.text = "the Power of Lifesteal";
        }
        effectSacrifice.text = "-" + baseHealthTosacrifice + " current base health for";
        cardsStuffleft = GameObject.FindGameObjectWithTag("nightmarecardL").transform;
        cardsStuffMiddle = GameObject.FindGameObjectWithTag("nightmarecardM").transform;
        cardsStuffRight = GameObject.FindGameObjectWithTag("nightmarecardR").transform;
    }

    public void SacrificeWeaponLevelUp()
    {
        if (targetPlayer.GetComponent<Weapon>().weaponLevel <= 3)
        {
            targetPlayer.GetComponent<Weapon>().weaponLevel++;
        }
        else
        {
            targetPlayer.GetComponent<Weapon>().IsLifeSteal = true;
        }

        targetBase.SendMessage("Damagetobase", baseHealthTosacrifice);
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
