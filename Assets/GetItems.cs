using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetItems : MonoBehaviour {

    private string uri = "https://5sd02u10pk.execute-api.eu-central-1.amazonaws.com/dev/softcore/shop/equipment/";

    // Use this for initialization
    void Start () {
        StartCoroutine(GetRequest(uri));
    }


    IEnumerator GetRequest(string uri)
    {

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SetRequestHeader("auth", "6e6f4b1d-3444-4860-b3d9-a42a065bc438");
        yield return request.SendWebRequest();

        // Show results as text        
        Debug.Log(request.downloadHandler.text);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
