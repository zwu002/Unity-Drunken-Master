using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    float fillAmount;

    [SerializeField]
    Image mask;

    GameObject uiManager;

	// Use this for initialization
	void Start () {
        uiManager = GameObject.Find("UIManager");
    }
	
	// Update is called once per frame
	void Update () {
        fillAmount = uiManager.GetComponent<UIManager>().drunkness / 100;
        HandleBar();
	}

    void HandleBar()
    {
        mask.fillAmount = fillAmount;
    }
}
