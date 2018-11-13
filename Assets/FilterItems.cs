using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class FilterItems : MonoBehaviour {
    private string uri = "https://5sd02u10pk.execute-api.eu-central-1.amazonaws.com/dev/softcore/shop/equipment/";

    public GameObject buttonParent;
    public GameObject marketItemButton;
    public GameObject[] listbutton;
    public Dropdown dropDown;
    public Button Search;
    public InputField input;

    Vector3 pos;
    // Use this for initialization
    void Start () {

        
        Search.onClick.AddListener(SearchItems);



    }

    void SearchItems()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("GameController"))
        {
            Destroy(go);
        }
        //Filtering with price
        if(dropDown.value == 0)
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
        //Debug.Log(i + " " + k);

        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
        //listbutton = new List<GameObject>(root.data.Count);
        try
        {
            int l = 0;
            double inputtext = double.Parse(input.text);
            Debug.Log(inputtext);
            for (int i = 0; i < root.data.Count; i++)
            {

                if (root.data[i].price <= inputtext)
                {
                    listbutton[i] = Instantiate(marketItemButton);
                    pos = listbutton[i].transform.position = new Vector2(0, 350);
                    pos.y -= 100f * l;
                    listbutton[i].transform.position = pos;
                    listbutton[i].transform.SetParent(buttonParent.transform, false);
                    listbutton[i].GetComponentInChildren<Text>().text = "   Item: " + root.data[i].item_id + ". Price :" + root.data[i].price + " KYRPEÄ";
                    l++;
                }

            }
        }

        catch(Exception e)
        {
            input.text = "0";
        }

        return JsonUtility.FromJson<RootObject>(jsonString);
    }

    // Update is called once per frame
    void Update () {

    }
}
