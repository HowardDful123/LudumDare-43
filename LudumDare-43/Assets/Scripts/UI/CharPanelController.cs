using UnityEngine;
using UnityEngine.UI;

public class CharPanelController : MonoBehaviour {
    public Animator charstat;
    public Button button;
    public Sprite inSprite;
    public Sprite outSprite;

    private bool InorOut;

    public void UpdateCharStatUI()
    {
        if (!InorOut)
        {
            button.GetComponent<Image>().sprite = inSprite;
            InorOut = true;
            charstat.SetBool("InOrOut", true);
        }
        else
        {
            button.GetComponent<Image>().sprite = outSprite;
            InorOut = false;
            charstat.SetBool("InOrOut", false);
        }
    }
}
