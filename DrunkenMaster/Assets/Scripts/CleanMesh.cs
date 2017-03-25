using UnityEngine;
using System.Collections;

public class CleanMesh: MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            col.gameObject.SetActive(false);
        }
    }
}
