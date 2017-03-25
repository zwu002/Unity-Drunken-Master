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
            col.gameObject.SetActive(false);
    }
}
