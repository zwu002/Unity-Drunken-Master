using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

    public float msToWait = 5000;

    Button chestButton;

    ulong lastChestOpen;

    void Start()
    {
        chestButton = GetComponent<Button>();
        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));

        if (!IsChestReady())
        {
            chestButton.interactable = false;
        }
    }

    void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
            }
        }
    }


    public void ChestClick ()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", DateTime.Now.Ticks.ToString());
        chestButton.interactable = false;
    }

    bool IsChestReady ()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (msToWait - m) / 1000;

        Debug.Log(secondsLeft);

        if (secondsLeft < 0.01f)
        {
            chestButton.interactable = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
