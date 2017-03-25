using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] spawnObstacle;

    public int randomPos;
    public float pos;
    public float minPosZ;
    public float maxPosZ;

    float timer;
    int obstacleIndex;

	void Start () {
        timer = 2f;
	}
	
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            obstacleIndex = Random.Range(0, 3);
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
 
            timer = Random.Range(0.2f, 2f);
        }
	}
}
