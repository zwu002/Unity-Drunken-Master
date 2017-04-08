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

    }

    // Update is called once per frame
    void Update () {
        coinText.text = "x " + PlayerPrefs.GetInt("coins");
        diamondText.text = "x " + PlayerPrefs.GetInt("diamonds");
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

}
