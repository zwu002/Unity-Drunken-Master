using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float speed;

    Vector3 position;

    public GameObject spawn;

    // Use this for initialization
    void Start () { 

        position = gameObject.transform.position;

        spawn = GameObject.Find("UIManager");
    }
	
	// Update is called once per frame
	void Update () {
        position.z -= 0.02f * speed * Time.timeScale;

        transform.position = position;

        speed = spawn.GetComponent<Spawn>().universalSpeed;
    }
}
