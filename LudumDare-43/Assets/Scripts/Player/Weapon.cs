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
    public Image reloadingBar;
    public AudioSource reloadingsound, shootingsound;

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
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        if (Input.GetButton("Fire1"))
        {
            if (!justShot)
            {
                Shoot();
            }
        }

        if (isReloading)    
        {
            if (!reloadingsound.isPlaying)
            {
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
        if (!isReloading && currentAmmo > 0)
        {
            if (weaponLevel == 0) Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
            if (weaponLevel == 1)
            {
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
            }
            if (weaponLevel == 2)
            {
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
            }
            if (weaponLevel == 3)
            {
                Instantiate(BulletTrailPrefab, shootingPointfarleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointleft.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointright.position, shootingPoint.rotation);
                Instantiate(BulletTrailPrefab, shootingPointfarright.position, shootingPoint.rotation);
            }
            if (weaponLevel >= 4)
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
