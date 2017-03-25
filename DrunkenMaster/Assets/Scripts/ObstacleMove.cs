using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float speed;

    Vector3 position;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        position = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        position.z -= 0.02f;

        transform.position = position;
    }
}
