using UnityEngine;
using System.Collections;

public class Punk : MonoBehaviour {

    public GameObject uiManager;

    int comboNum;
    public int performComboNum;

    public float comboTime;
    float previousTime;

    void Start () {
        uiManager = GameObject.Find("UIManager");

        comboNum = 0;
        previousTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);

            uiManager.GetComponent<UIManager>().hitPunk();
            uiManager.GetComponent<UIManager>().drunknessminus();
            uiManager.GetComponent<Spawn>().DetectKongfuCombo();
        }
    }
}
