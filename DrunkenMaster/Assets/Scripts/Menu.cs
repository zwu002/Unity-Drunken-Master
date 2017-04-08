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

        coinsOld = PlayerPrefs.GetInt("coins");
        diamondsOld = PlayerPrefs.GetInt("diamonds");

        if (!PlayerPrefs.HasKey("UnlockLevel2"))
        {
            PlayerPrefs.SetInt("UnlockLevel2", 0);
        }

        if (PlayerPrefs.GetInt("UnlockLevel2") == 0)
        {
            buttons[1].interactable = false;
        }
    }

    // Update is called once per frame
    void Update () {
        coinText.text = "x " + PlayerPrefs.GetInt("coins");
        diamondText.text = "x " + PlayerPrefs.GetInt("diamonds");

        if (PlayerPrefs.GetInt("coins") > 20 && PlayerPrefs.GetInt("UnlockLevel2") == 0)
        {
            buttons[3].interactable = true;
        }
        else buttons[3].interactable = false;

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
}
