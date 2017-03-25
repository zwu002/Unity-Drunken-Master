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

	void Start () {
        drunkness = 50;
        score = 0;
        distance = 0;
        Time.timeScale = 1;
        currentScene = SceneManager.GetActiveScene();
        gameOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
        distanceText.text = "Distance: " + distance;
        drunknessText.text = "Drunkness: " + drunkness;
    }
}
