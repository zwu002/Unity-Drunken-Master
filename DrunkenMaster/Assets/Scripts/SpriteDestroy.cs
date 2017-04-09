using UnityEngine;
using System.Collections;

public class SpriteDestroy : MonoBehaviour {

    float timer;
    float destroyTime;

	// Use this for initialization
	void Start () {
        timer = Time.time;
        destroyTime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	  if (Time.time - timer > destroyTime)
        {
            gameObject.SetActive(false);
        }
	}
}
