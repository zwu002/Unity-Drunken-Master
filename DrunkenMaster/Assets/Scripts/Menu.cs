using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text coinText;
    public Text diamondText;

    Scene currentScene;

    public int coinsOld;
    public int diamondsOld;

    public Button[] buttons;

    void Start () {

        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 0);
        }

        if (!PlayerPrefs.HasKey("diamonds"))
        {
            PlayerPrefs.SetInt("diamonds", 0);
        }

        if (!PlayerPrefs.HasKey("chooseUK"))
        {
            PlayerPrefs.SetInt("chooseUK", 0);
        }

        if (!PlayerPrefs.HasKey("chooseGerman"))
        {
            PlayerPrefs.SetInt("chooseGerman", 0);
        }

        if (!PlayerPrefs.HasKey("unlockGerman"))
        {
            PlayerPrefs.SetInt("unlockGerman", 0);
        }

        coinsOld = PlayerPrefs.GetInt("coins");
        diamondsOld = PlayerPrefs.GetInt("diamonds");

        if (!PlayerPrefs.HasKey("UnlockLevel2"))
        {
            PlayerPrefs.SetInt("UnlockLevel2", 0);
        }

        if (PlayerPrefs.GetInt("UnlockLevel2") == 1)
        {
            buttons[1].interactable = true;
        }
        else buttons[1].interactable = false;

        if (PlayerPrefs.GetInt("unlockGerman") == 1)
        {
            buttons[5].interactable = true;
        }
        else buttons[5].interactable = false;
    }

    // Update is called once per frame
    void Update () {

        coinsOld = PlayerPrefs.GetInt("coins");
        diamondsOld = PlayerPrefs.GetInt("diamonds");

        coinText.text = "x " + PlayerPrefs.GetInt("coins");
        diamondText.text = "x " + PlayerPrefs.GetInt("diamonds");

        if (PlayerPrefs.GetInt("coins") >= 20 && PlayerPrefs.GetInt("UnlockLevel2") == 0)
        {
            buttons[3].interactable = true;
        }
        else buttons[3].interactable = false;

        if (PlayerPrefs.GetInt("diamonds") >= 5 && PlayerPrefs.GetInt("unlockGerman") == 0)
        {
            buttons[6].interactable = true;
        }
        else buttons[6].interactable = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayLevelI()
    {
        SceneManager.LoadScene("level1");
    }

    public void PlayLevelII()
    {
        SceneManager.LoadScene("level2");
    }

    public void UnlockLevel2 ()
    {
        PlayerPrefs.SetInt("UnlockLevel2", 1);
        buttons[1].interactable = true;
        buttons[3].interactable = true;
        PlayerPrefs.SetInt("coins", coinsOld - 20);
        coinsOld = PlayerPrefs.GetInt("coins");
    }

    public void UnlockGerman()
    {
        PlayerPrefs.SetInt("unlockGerman", 1);
        buttons[5].interactable = true;
        buttons[6].interactable = false;
        PlayerPrefs.SetInt("diamonds", diamondsOld - 5);
        diamondsOld = PlayerPrefs.GetInt("diamonds");
    }

    public void ChooseUK()
    {
        PlayerPrefs.SetInt("chooseUK", 1);
        PlayerPrefs.SetInt("chooseGerman", 0);
        buttons[4].interactable = false;
        if (PlayerPrefs.GetInt("unlockGerman") == 1)
        {
            buttons[5].interactable = true;
        }
    }

    public void ChooseGerman()
    {
        PlayerPrefs.SetInt("chooseGerman", 1);
        PlayerPrefs.SetInt("chooseUK", 0);
        buttons[5].interactable = false;
        buttons[4].interactable = true;
    }
}
