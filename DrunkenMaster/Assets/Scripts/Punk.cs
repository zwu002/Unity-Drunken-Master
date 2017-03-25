using UnityEngine;
using System.Collections;

public class Punk : MonoBehaviour {

    public GameObject uiManager;

    void Start () {
        uiManager = GameObject.Find("UIManager");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);

            uiManager.GetComponent<UIManager>().scoreUpdate();
            uiManager.GetComponent<UIManager>().drunknessminus();
        }
    }
}
