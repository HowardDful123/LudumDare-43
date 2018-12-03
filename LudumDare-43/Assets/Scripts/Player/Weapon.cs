using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform shootingPoint;
    public Transform shootingPointleft;
    public Transform shootingPointfarleft;
    public Transform shootingPointright;
    public Transform shootingPointfarright;
    public Transform BulletTrailPrefab;
    public float fireRate = 1.2f;
    public int ammoCapcity = 20;
    public int currentAmmo = 20;
    public float reloadTime;
    public Text ammotext;
    public Image reloadingBar;
    public AudioSource reloadingsound, shootingsound, crackinggun;

    [Header("Unity CHARSTAT!")]
    public Text fireratestat;
    public Text weaponlevelstat;

    [SerializeField]
    WaveSpawner spawner;

    private WaveSpawner.SpawnState previousState;
    private bool isLifeSteal;
    private float firecounter;
    private float reloadCounter;
    private bool isReloading;
    public int weaponLevel = 0;
    private bool justShot;

    public bool IsLifeSteal
    {
        get
        {
            return isLifeSteal;
        }

        set
        {
            isLifeSteal = value;
        }
    }

    // Use this for initialization
    void Start () {
        previousState = spawner.State;
    }
	
	// Update is called once per frame
	void Update () {
        ammotext.text = "Ammo: " + currentAmmo + "/" + ammoCapcity;
        if (weaponLevel < 3)
        {
            weaponlevelstat.text = "Shooting " + (weaponLevel + 1) + " Projectiles";
        }
        else if (weaponLevel == 3)
        {
            weaponlevelstat.text = "Shooting " + (weaponLevel + 5) + " Projectiles";
        }
        else if (weaponLevel >= 4)
        {
            weaponlevelstat.text = "Shooting " + 6 + " Projectiles and lifestealing [MAXED]" ;
        }
        fireratestat.text = "Firerate: " + fireRate.ToString("F2");

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        if (Input.GetButton("Fire1"))
        {
            if (!justShot)
            {
                if (spawner.State != previousState)
                {
                    Shoot();
                }
            }
        }

        if (isReloading)    
        {
            if (!reloadingsound.isPlaying)
            {
                StopPlayingSound(crackinggun);
                PlaySound(reloadingsound);
            }
            reloadCounter += Time.deltaTime;
            reloadingBar.fillAmount = reloadCounter / 2f;
            if (reloadCounter >= reloadTime)
            {
                StopPlayingSound(reloadingsound);
                reloadCounter = 0f;
                currentAmmo = ammoCapcity;
                isReloading = false;
            }
        }

        if (justShot)
        {
            firecounter += Time.deltaTime;
            if (firecounter >= fireRate)
            {
                firecounter = 0f;
                justShot = false;
            }
        }
    }

    void Shoot()
    {
        if (!isReloading && currentAmmo <= 0)
        {
            if (!crackinggun.isPlaying)
            {
                PlaySound(crackinggun);
            }
        }

        if (!isReloading && currentAmmo > 0)
        {
            if (weaponLevel == 0) Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
            else if (weaponLevel == 1)
            {
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
            }
            else if (weaponLevel == 2)
            {
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
            }
            else if (weaponLevel == 3)
            {
                Instantiate(BulletTrailPrefab, shootingPointfarleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointfarright.position, shootingPoint.rotation);
            }
            else if (weaponLevel >= 4)
            {
                isLifeSteal = true;
                Instantiate(BulletTrailPrefab, shootingPointfarleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointfarright.position, shootingPoint.rotation);
            }
            PlaySound(shootingsound);
            currentAmmo--;
            justShot = true;
        }
        
    }

    void Reload()
    {
        if (currentAmmo < ammoCapcity)
        {
            isReloading = true;
        }
    }

    void PlaySound(AudioSource sound)
    {
        sound.volume = Random.Range(0.5f, 0.7f);
        sound.pitch = Random.Range(0.8f, 1f);
        sound.Play();
    }

    void StopPlayingSound(AudioSource sound)
    {
        sound.Stop();
    }
}
