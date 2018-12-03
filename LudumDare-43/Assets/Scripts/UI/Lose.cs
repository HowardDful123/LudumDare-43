using UnityEngine.SceneManagement;
using UnityEngine;

public class Lose : MonoBehaviour {

    public void PlayAgain()
    {
        SceneManager.LoadScene("Hao");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
