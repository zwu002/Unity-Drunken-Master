using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float speed;

    Vector3 position;

    Rigidbody rb;

    public GameObject spawn;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

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
