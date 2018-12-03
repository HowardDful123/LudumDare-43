using UnityEngine;
using UnityEngine.UI;

public class UIWave : MonoBehaviour {


    [SerializeField]
    WaveSpawner spawner;

    [SerializeField]
    Animator waveAnimator;

    [SerializeField]
    Text waveCountDownText;

    [SerializeField]
    Text waveCountText;

    private WaveSpawner.SpawnState previousState;

    // Use this for initialization
    void Start () {
        if (spawner == null)
        {
            Debug.LogError("No Spawner Referenced");
            this.enabled = false;
        }
        if (waveAnimator == null)
        {
            Debug.LogError("No Spawner Referenced");
            this.enabled = false;
        }
        if (waveCountDownText == null)
        {
            Debug.LogError("No Spawner Referenced");
            this.enabled = false;
        }
        if (waveCountText == null)
        {
            Debug.LogError("No Spawner Referenced");
            this.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        switch (spawner.state)
        {
            case WaveSpawner.SpawnState.counting:
                UpdateCountdownUI();
                break;
            case WaveSpawner.SpawnState.spawning:
                UpdateSpawningUI();
                break;
        }

        previousState = spawner.State;
	}

    void UpdateCountdownUI()
    {
        if (previousState != WaveSpawner.SpawnState.counting)
        {
            waveAnimator.SetBool("WaveIncoming", false);
            waveAnimator.SetBool("WaveCountdown",true);
            Debug.Log("Counting");
        }
        waveCountDownText.text = ((int)spawner.WaveCountDown).ToString();
    }
    void UpdateSpawningUI()
    {
        if (previousState != WaveSpawner.SpawnState.spawning)
        {
            waveAnimator.SetBool("WaveCountdown", false);
            waveAnimator.SetBool("WaveIncoming", true);

            waveCountText.text = spawner.waves[spawner.NextWave].name;

            Debug.Log("Spawning");
        }
    }
}
