using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenetomarkget : MonoBehaviour {

    public Button scenechagne;
	// Use this for initialization
	void Start () {

        scenechagne.onClick.AddListener(ChangeScene);
	}

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
