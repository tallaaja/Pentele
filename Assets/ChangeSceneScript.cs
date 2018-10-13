using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneScript : MonoBehaviour {

    public Button changescene;
	// Use this for initialization
	void Start () {

        changescene.onClick.AddListener(ChangeScene);

		
	}

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
