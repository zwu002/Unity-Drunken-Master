using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] spawnObstacle;
    public GameObject spawnUK;
    public GameObject spawnGerman;
    GameObject uiManager;

    public AudioSource[] playsound;

    public int randomPos;
    public float pos;
    public float minPosZ;
    public float maxPosZ;
    public float universalSpeed;

    float timer;
    float speedupIndex;
    int obstacleIndex;

    // Drinking Streak Detection
    int comboNumDrink;
    public int performComboNumDrink;

    public float comboTimeDrink;
    float previousTimeDrink;

    // Kongfu Combo Detection
    [SerializeField]
    int comboNumKF;
    public int performComboNumKF;

    public float comboTimeKF;
    float previousTimeKF;


    void Start () {
        timer = 1f;
        speedupIndex = 0;
        universalSpeed = 1;
        uiManager = GameObject.Find("UIManager");

        if (PlayerPrefs.GetInt("chooseGerman") == 1)
        {
            Instantiate(spawnGerman, new Vector3(-0.044f, 0.092f, -2.8f), Quaternion.identity);
        }
        else
        {
            Instantiate(spawnUK, new Vector3(-0.044f, 0.11f, -2.8f), Quaternion.identity);
        }
    }
	
	void Update () {

        // Combos detection
        if (Time.time - previousTimeDrink >= comboTimeDrink)
        {
            comboNumDrink = 0;
        }

        if (Time.time - previousTimeKF >= comboTimeKF)
        {
            comboNumKF = 0;
        }


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            obstacleIndex = Random.Range(0, 4);
            randomPos = Random.Range(0, 3);

            if (randomPos == 0)
            {
                pos = -0.5f;
            }
            else if (randomPos == 1)
            {
                pos = 0;
            }
            else
            {
                pos = 0.5f;
            }

            Instantiate(spawnObstacle[obstacleIndex], new Vector3(pos, 0.15f, Random.Range(minPosZ, maxPosZ)), Quaternion.identity);

            speedupIndex++;
 
            timer = Random.Range(0.4f, 1f);

            if (speedupIndex >= 10)
            {
                Speedup();
                speedupIndex = 0;
            }
        }
	}

    void Speedup()
    {
        universalSpeed += 0.2f;
    }

    void Speeddown()
    {
        universalSpeed -= 0.2f;
    }

    public void DetectDrinkingStreak()
    {
        if (comboNumDrink == 0)
        {
            comboNumDrink++;
            previousTimeDrink = Time.time;
        }
        else if (comboNumDrink > 0 && comboNumDrink < performComboNumDrink)
        {
            comboNumDrink++;
        }
        else if (comboNumDrink >= performComboNumDrink && (Time.time - previousTimeDrink) < comboTimeDrink)
        {
            uiManager.GetComponent<UIManager>().DrinkingStreak();
            playsound[1].Play();
            comboNumDrink = 0;
            previousTimeDrink = Time.time;
        }
        else if (comboNumDrink >= performComboNumDrink && (Time.time - previousTimeDrink) >= comboTimeDrink)
        {
            comboNumDrink = 0;
            previousTimeDrink = Time.time;
        }
    }

    public void DetectKongfuCombo()
    {
        if (comboNumKF == 0)
        {
            comboNumKF++;
            previousTimeKF = Time.time;
        }
        else if (comboNumKF > 0 && comboNumKF < performComboNumKF)
        {
            comboNumKF++;
        }
        else if (comboNumKF >= performComboNumKF && (Time.time - previousTimeKF) < comboTimeKF)
        {
            uiManager.GetComponent<UIManager>().KongfuCombo();
            playsound[3].Play();
            comboNumKF = 0;
            previousTimeKF = Time.time;
        }
        else if (comboNumKF >= performComboNumKF && (Time.time - previousTimeKF) >= comboTimeKF)
        {
            comboNumKF = 0;
            previousTimeKF = Time.time;
        }
    }
}
