using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMap : MonoBehaviour {
    public Text console;
    public string prefabname;
    public Material[] HexMaterials;
    public PhotonView photonView = new PhotonView();
    public string grassPrefabname = "hexGrass";
    public string waterPrefabname = "hexWater";
    public string mountainPrefabname = "hexMountain";
    Vector2[] touches = new Vector2[5];

    public GameObject selectedUnit;

    // Use this for initialization
    void Start() {

    }

    [PunRPC]
    void addMaterials()
    {
       // MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();
        //mr.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
    }

    string getRandomHex()
    {

        int i = Random.Range(0, 3);
        if (i == 0) return grassPrefabname;
        if (i == 1) return waterPrefabname;
        if (i == 2) return mountainPrefabname;
        else return null;

    }

    public void GenerateMap()
    {

        for(int column = 0; column < 15; column++)
        {
            for(int row = 0; row < 15; row++)
            {
                //instantiate hex
                Hex h = new Hex(column, row);
                GameObject hexGo = (GameObject) PhotonNetwork.Instantiate(getRandomHex(),
                    h.Position(),
                    Quaternion.identity, 0);
             }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                console.text = "adlskj";
                touches[t.fingerId] = Camera.main.ScreenToWorldPoint(Input.GetTouch(t.fingerId).position);
                if (Input.GetTouch(t.fingerId).phase == TouchPhase.Began)
                    hit = Physics2D.Raycast(touches[t.fingerId], Vector2.zero);
                if (hit.collider.tag == "Player")
                {
                    selectedUnit = hit.collider.gameObject;
                    console.text = "Player";
                }
                    

                if(selectedUnit != null)
                {
                    selectedUnit.transform.parent.position = hit.collider.transform.position;
                }
            }
        }
            if (Input.GetMouseButtonDown(0))
            {
            
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("seomthin clikced");
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("oplayer");
                    selectedUnit = hit.collider.gameObject;
                }

                if (selectedUnit != null)
                {
                    selectedUnit.transform.parent.position = hit.collider.transform.position;
                }
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }


            }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("asdlökj");
            selectedUnit = null;
        }
    }

}

