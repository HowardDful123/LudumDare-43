using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour {
    public float currentHealth;
    public float health = 5000;


    [Header("Unity HEALTH!")]
    public Image healthBar;
    public TextMesh healthText;

    private float timeElapsedColor;
    private bool isColorChanged;
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth + "/" + health;

        if (isColorChanged)
        {
            timeElapsedColor += Time.deltaTime;
            if (timeElapsedColor >= .25f)
            {
                timeElapsedColor = 0;
                isColorChanged = false;
                ResetColor();
            }
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void Damagetobase(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / health;
        ChangeColor();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
}
