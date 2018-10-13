using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;

public class SellItem : MonoBehaviour {

    public Button sellBtn;

	// Use this for initialization
	void Start () {
        sellBtn.onClick.AddListener(Sell);

    }
    [Serializable]
    public class MyClass
    {
        public string player_id;
        public int item_id;
        public int price;
    }
    void Sell(){

        MyClass b = new MyClass { player_id = "def30c53-d36e-424a-a399-35fe43151c08", item_id = 1011, price = 500 };
        string postData = JsonConvert.SerializeObject(b);
        
        //string JSON_Body = "{'player_id':'def30c53 - d36e - 424a - a399 - 35fe43151c08','item_id':715517,'price':1111}";
        string uri = "https://5sd02u10pk.execute-api.eu-central-1.amazonaws.com/dev/softcore/shop/equipment/sell/";

        StartCoroutine(SellRequest(uri, postData));

    }

    IEnumerator SellRequest(string uri, string bodyJsonString)
    {
       
        var request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("auth", "6e6f4b1d-3444-4860-b3d9-a42a065bc438");
        
        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }

    }

        // Update is called once per frame
        void Update () {
		
	}
}
