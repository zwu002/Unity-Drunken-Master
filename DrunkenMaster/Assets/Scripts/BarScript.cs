using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    float fillAmount;

    [SerializeField]
    Image mask;

    GameObject uiManager;

	void Start () {
        uiManager = GameObject.Find("UIManager");
    }
	
	void Update () {
        fillAmount = uiManager.GetComponent<UIManager>().drunkness / 100;
        HandleBar();
	}

    void HandleBar()
    {
        mask.fillAmount = fillAmount;
    }
}
