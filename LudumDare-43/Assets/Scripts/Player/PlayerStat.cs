﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour {
    public float currentHealth;
    public float health = 50f;
    public int gunDamage = 10;

    [Header("Unity CHARSTAT!")]
    public Image healthBar;
    public Text healthText;
    public Text damagestat;

    private float timeElapsedColor;
    private bool isColorChanged;
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update () {
        damagestat.text = "Damage: " + gunDamage;
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

        if (gunDamage <= 0)
        {
            gunDamage = 1;
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FillHealthBar();
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

    public void FillHealthBar()
    {
        healthBar.fillAmount = currentHealth / health;
    }
}
