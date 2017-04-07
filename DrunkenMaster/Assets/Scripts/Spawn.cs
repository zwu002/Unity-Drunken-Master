using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] spawnObstacle;

    public int randomPos;
    public float pos;
    public float minPosZ;
    public float maxPosZ;
    public float universalSpeed;

    float timer;
    float speedupIndex;
    int obstacleIndex;

	void Start () {
        timer = 1f;
        speedupIndex = 0;
        universalSpeed = 1;
	}
	
	void Update () {
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
}
