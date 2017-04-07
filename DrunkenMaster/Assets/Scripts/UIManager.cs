using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Scene currentScene;

    public float drunkness;
    public float score;
    public float distance;

    bool gameOver;

    public Text scoreText;
    public Text distanceText;
    public Text drunknessText;
    public Text gameOverScoreText;
    public Text gameOverDistanceText;
    public Text highScoreText;

    public Button[] buttons;

    public GameObject uiManager;

	void Start () {
        drunkness = 50;
        score = 0;
        distance = 0;
        Time.timeScale = 1;
        currentScene = SceneManager.GetActiveScene();
        gameOver = false;

        uiManager = GameObject.Find("UIManager");
    }
	
	// Update is called once per frame
	void Update () {
        score += 10 * Time.deltaTime * uiManager.GetComponent<Spawn>().universalSpeed;
        distance += Time.deltaTime * uiManager.GetComponent<Spawn>().universalSpeed;

        scoreText.text = "Score: " + (int) score;
        distanceText.text = "Distance: " + (int) distance;
        drunknessText.text = "Drunkness: " + (int) drunkness;
        drunkness -= Time.deltaTime;

        if (gameOver == true)
        {
            Gameover();
        }
    }

    public void scoreUpdate()
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
        score -= 800;
    }

    public void Gameover ()
    {
        gameOver = true;

        gameOverScoreText.text = "YOUR SCORE" + "\r\n" + score;
        gameOverDistanceText.text = "YOUR DISTANCE" + "\r\n" + distance;
        gameOverScoreText.gameObject.SetActive(true);
        gameOverDistanceText.gameObject.SetActive(true);

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("HighScore") < (int)score)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }

        Time.timeScale = 0;
}

    public void Replay()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayLevelI()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevelII()
    {
        SceneManager.LoadScene("Level2");
    }
}
