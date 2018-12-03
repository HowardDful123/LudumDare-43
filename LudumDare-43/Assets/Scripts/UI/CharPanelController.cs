using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPanelController : MonoBehaviour {
    public Animator charstat;

    private bool InorOut;

    public void UpdateCharStatUI()
    {
        if (!InorOut)
        {
            InorOut = true;
            charstat.SetBool("InOrOut", true);
        }
        else
        {
            InorOut = false;
            charstat.SetBool("InOrOut", false);
        }
    }
}
