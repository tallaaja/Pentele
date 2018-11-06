using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetItems : MonoBehaviour {

    public GameObject page;
    public GameObject testi;
    public GameObject marketItemButton;
    public GameObject thiscanvas;
    private string uri = "https://5sd02u10pk.execute-api.eu-central-1.amazonaws.com/dev/softcore/shop/equipment/";

    // Use this for initialization
    void Start () {
        if (this.isActiveAndEnabled)
        {
            StartCoroutine(GetRequest(uri));
        }
        
    }

    [Serializable]
    public class Datum
    {
        public double price;
        public double item_id;
        public string owner_id;
    }
    [Serializable]
    public class RootObject
    {
        public int statusCode;
        public List<Datum> data;
    }

    IEnumerator GetRequest(string uri)
    {

        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.SetRequestHeader("auth", "6e6f4b1d-3444-4860-b3d9-a42a065bc438");
        yield return request.SendWebRequest();

        // Show results as text        
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {

            string items = request.downloadHandler.text;
            Debug.Log("Items is shop: " + request.downloadHandler.text);
            CreateFromJSON(items);


        }
    }

    public RootObject CreateFromJSON(string jsonString)
    {
        
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
        for(int i = 0; i < root.data.Count; i++)
        {
            GameObject listbutton = Instantiate(marketItemButton);
            Vector3 pos = listbutton.transform.position;
            pos.y -= 100f * i;
            listbutton.transform.position = pos;
            listbutton.transform.SetParent(testi.transform, false);
            listbutton.GetComponentInChildren<Text>().text = "Item: " + root.data[i].item_id + ". Price :" + root.data[i].price + " KYRPEÄ";

            if(i > 5)
            {
                GameObject pageGo = Instantiate(page);
                Vector3 pos2 = pageGo.transform.position;
                pos2.y -= 100f * i;
                pageGo.transform.position = pos;
                pageGo.transform.SetParent(this.transform, false);
            }

            //Debug.Log("Item " + i+1 + ": " +root.data[i].item_id);
        }
        
        return JsonUtility.FromJson<RootObject>(jsonString);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
