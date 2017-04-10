using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Scene currentScene;
    public GameObject drinkingStreakSprite;
    public GameObject kongfuComboSprite;

    public float drunkness;
    public float score;
    public float distance;

    [SerializeField]
    float coins;
    float diamonds;

    public int coinsOld;
    public int diamondsOld;

    bool gameOver;

    public Text scoreText;
    public Text distanceText;
    public Text drunknessText;
    public Text gameOverScoreText;
    public Text gameOverDistanceText;
    public Text highScoreText;
    public Text coinText;
    public Text diamondText;

    public Button[] buttons;

    public GameObject uiManager;

	void Start () {
        drunkness = 50;
        score = 0;
        distance = 0;
        Time.timeScale = 1;
        currentScene = SceneManager.GetActiveScene();
        gameOver = false;

        coins = 0;
        diamonds = 0;

        uiManager = GameObject.Find("UIManager");

        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }

        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 0);
        }

        if (!PlayerPrefs.HasKey("diamonds"))
        {
            PlayerPrefs.SetInt("diamonds", 0);
        }

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore");
        coinText.text = "x " + PlayerPrefs.GetInt("coins");
        diamondText.text = "x " + PlayerPrefs.GetInt("diamonds");

        coinsOld = PlayerPrefs.GetInt("coins");
        diamondsOld = PlayerPrefs.GetInt("diamonds");
    }
	
	// Update is called once per frame
	void Update () {
        score += 10 * Time.deltaTime * uiManager.GetComponent<Spawn>().universalSpeed;
        distance += Time.deltaTime * uiManager.GetComponent<Spawn>().universalSpeed;

        scoreText.text = "Score: " + (int) score;
        distanceText.text = "Distance: " + (int) distance;
        drunknessText.text = "Drunkness: " + (int) drunkness;
        drunkness -= Time.deltaTime;
        coinText.text = "x " + coinsOld;
        diamondText.text = "x " + diamondsOld;

        if (drunkness <= 0 || drunkness >= 100)
        {
            gameOver = true;
        }

        if (gameOver == true)
        {
            Gameover();
        }
    }

    public void hitPunk()
    {
        score += 50;
    }

    public void collectDrink()
    {
        score += 100;
    }

    public void drunknessplus()
    {
        drunkness += 20;
    }

    public void drunknessminus()
    {
        drunkness -= 10;
    }

    public void hitobs()
    {
        drunkness -= 70;
        uiManager.GetComponent<Spawn>().Speeddown();
    }

    public void DrinkingStreak()
    {
        score += 300;
        Instantiate(drinkingStreakSprite, new Vector3(0, 0.3f, -1.8f), Quaternion.identity);
    }

    public void KongfuCombo()
    {
        score += 200;
        Instantiate(kongfuComboSprite, new Vector3(0, 0.3f, -1.8f), Quaternion.identity);
    }

    public void Gameover ()
    {
        Time.timeScale = 0;

        coins = score / 100f;

        if ((int)score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
            diamonds = 5;
        }

        PlayerPrefs.SetInt("coins", (int)coins + coinsOld);
        PlayerPrefs.SetInt("diamonds", (int)diamonds + diamondsOld);

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
}

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(true);
            }

        }

        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

            // kill this when fixing UI
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }

        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("startmenu");
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
