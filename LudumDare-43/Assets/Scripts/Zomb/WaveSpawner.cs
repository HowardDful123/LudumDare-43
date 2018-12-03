using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { spawning, waiting, counting, cardchoose, cardwaiting}

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public int count;
        public float rate;
    }
    public Text wavenumber;
    public Text cardWaveNext;
    public Text cardCountD; 
    public Transform cardsStuffleft;
    public Transform cardsStuffMiddle;
    public Transform cardsStuffRight;
    public Transform nightcardsStuffleft;
    public Transform nightcardsStuffMiddle;
    public Transform nightcardsStuffRight;
    public Transform[] spawnPoints;
    public Wave[] waves;
    public SpawnState state = SpawnState.cardwaiting;
    public SpawnState State
    {
        get { return state; }
    }

    private int nextWave = 0;
    public int NextWave
    {
        get { return nextWave; }
    }

    public float cardCountDown;
    public float timeBetweenWaves = 5f;
    private float waveCountDown;
    public float WaveCountDown
    {
        get { return waveCountDown; }
    }
    private float searchCountDown = 1f;

    void Start()
    {
        cardWaveNext.text = "Wave next: " + waves[nextWave].name;
        wavenumber.text = "Wave " + (nextWave+1) + " of " + "15";
        cardsStuffleft.GetComponent<normalSprite>().SpawnCard("normalcard");
        cardsStuffMiddle.GetComponent<normalSprite>().SpawnCard("normalcardMid");
        cardsStuffRight.GetComponent<normalSprite>().SpawnCard("normalcardRight");
        //nightcardsStuffleft.GetComponent<nightmareSprite>().SpawnLeftCard("nightmarecardL");
        //nightcardsStuffMiddle.GetComponent<nightmareSprite>().SpawnMiddleCard("nightmarecardM");
        //nightcardsStuffRight.GetComponent<nightmareSprite>().SpawnRightCard("nightmarecardR");
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Point Referenced");
        }
        waveCountDown = timeBetweenWaves;
        cardCountDown = 30f;
    }

    void Update()
    {
        if (state == SpawnState.waiting)
        {
            if (!IsEnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        
       
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        if (state != SpawnState.cardwaiting)
        {
            waveCountDown -= Time.deltaTime;
            cardWaveNext.enabled = false;
            cardCountD.GetComponent<Text>().enabled = false;
        }

        if (state == SpawnState.cardwaiting)
        {            
            cardCountDown -= Time.deltaTime;
            cardCountD.text = cardCountDown.ToString("F1");
            if (cardCountDown <= 0)
            {
                state = SpawnState.counting;
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
                if (nightcardsStuffleft.childCount != 0)
                {
                    foreach (Transform child in cardsStuffleft)
                    {
                        Destroy(child.gameObject);
                    }
                }
                if (nightcardsStuffMiddle.childCount != 0)
                {
                    foreach (Transform child in cardsStuffMiddle)
                    {
                        Destroy(child.gameObject);
                    }
                }
                if (nightcardsStuffRight.childCount != 0)
                {
                    foreach (Transform child in cardsStuffRight)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            if (waves[nextWave].name != "Nightmare")
            {
                if (cardsStuffleft.childCount == 0)
                {
                    state = SpawnState.counting;
                }
                if (cardsStuffMiddle.childCount == 0)
                {
                    state = SpawnState.counting;
                }
                if (cardsStuffRight.childCount == 0)
                {
                    state = SpawnState.counting;
                }
            }
            
            if (waves[nextWave].name == "Nightmare")
            {
                if (nightcardsStuffleft.childCount == 0)
                {
                    state = SpawnState.counting;
                }
                if (nightcardsStuffMiddle.childCount == 0)
                {
                    state = SpawnState.counting;
                }
                if (nightcardsStuffRight.childCount == 0)
                {
                    state = SpawnState.counting;
                }
            }

        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.counting;
        waveCountDown = timeBetweenWaves;
        cardCountDown = 30f;

        if (nextWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene("Win");
            Debug.Log("You SURVIVED! ...Again?");
        }
        else
        {
            nextWave++;
            wavenumber.text = "Wave " + (nextWave + 1) + " of " + "15";
            StartCoroutine(CardChoose());
        }

        
    }

    bool IsEnemyAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("NZombie") == null)
            {
                return false;
            }
        }     
        return true;
    }

    IEnumerator CardChoose()
    {
        state = SpawnState.cardchoose;
        cardCountD.GetComponent<Text>().enabled = true;
        cardWaveNext.text = "Next Wave: " + waves[nextWave].name;
        cardWaveNext.enabled = true;
        if (waves[nextWave].name == "Nightmare")
        {
            nightcardsStuffleft.GetComponent<nightmareSprite>().SpawnLeftCard("nightmarecardL");
            nightcardsStuffMiddle.GetComponent<nightmareSprite>().SpawnMiddleCard("nightmarecardM");
            nightcardsStuffRight.GetComponent<nightmareSprite>().SpawnRightCard("nightmarecardR");
        }
        
        if (waves[nextWave].name != "Nightmare")
        {
            cardsStuffleft.GetComponent<normalSprite>().SpawnCard("normalcard");
            cardsStuffMiddle.GetComponent<normalSprite>().SpawnCard("normalcardMid");
            cardsStuffRight.GetComponent<normalSprite>().SpawnCard("normalcardRight");
        }
        
        state = SpawnState.cardwaiting;
        
        yield break;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.spawning;
        cardWaveNext.enabled = false;
        for (int i = 0; i < _wave.count; i++)
        {
            Spawn(_wave.enemies[Random.Range(0,_wave.enemies.Length)]);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.waiting;

        yield break;

    }

    void Spawn(GameObject _enemies)
    {
        Debug.Log("Spawning Zombie" + _enemies.name);
        

        Transform _sp = spawnPoints[ Random.Range(0,spawnPoints.Length)];
        Instantiate(_enemies, _sp.position, _sp.rotation);
    }
}
