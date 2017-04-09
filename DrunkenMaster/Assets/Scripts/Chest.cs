using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

    public float msToWait = 3600000;

    Button chestButton;
    Text chestTimer;

    ulong lastChestOpen;

    public GameObject uiManager;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LastChestOpen"))
        {
            PlayerPrefs.SetString("LastChestOpen", DateTime.Now.Ticks.ToString());
        }

        chestButton = GetComponent<Button>();
        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));
        chestTimer = GetComponentInChildren<Text>();
        uiManager = GameObject.Find("UIManager");


            chestButton.interactable = false;
    }

    void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
                chestTimer.text = "Ready!";
            }
            else
            {
                // Set Timer
                ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float secondsLeft = (msToWait - m) / 1000;

                string r = "";
                // Hours
                r += ((int)secondsLeft / 3600).ToString() + "h ";
                secondsLeft -= ((int)secondsLeft / 3600) * 3600;
                // Minutes
                r += ((int)secondsLeft / 60).ToString("00") + "m ";
                // Seconds
                r += (secondsLeft % 60).ToString("00") + "s ";

                chestTimer.text = r;
            }
        }
    }


    public void ChestClick ()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastChestOpen", DateTime.Now.Ticks.ToString());
        chestButton.interactable = false;

        // Give player gold
        PlayerPrefs.SetInt("coins", 20 + uiManager.GetComponent<Menu>().coinsOld);
        

    }

    bool IsChestReady ()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (msToWait - m) / 1000;

        if (secondsLeft < 0.01f)
        {
            chestButton.interactable = true;
            chestTimer.text = "Ready!";
            return true;
        }
        else
        {
            return false;
        }
    }
}
