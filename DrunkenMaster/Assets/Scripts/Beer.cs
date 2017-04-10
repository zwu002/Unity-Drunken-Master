using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {

    public GameObject uiManager;

    public float point;
    public float drunkness;

    int comboNum;
    public int performComboNum;

    public float comboTime;
    float previousTime;

    void Start () {
        uiManager = GameObject.Find("UIManager");
    }
	
	// Update is called once per frame
	void Update () {
	  if (Time.time - previousTime >= comboTime)
        {
            comboNum = 0;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            uiManager.GetComponent<UIManager>().beerpoint = point;
            uiManager.GetComponent<UIManager>().drunknesspoint = drunkness;
            uiManager.GetComponent<UIManager>().collectDrink();
            uiManager.GetComponent<UIManager>().drunknessplus();
            uiManager.GetComponent<Spawn>().DetectDrinkingStreak();
            uiManager.GetComponent<Spawn>().playsound[0].Play();

            gameObject.SetActive(false);
        }
    }
}
