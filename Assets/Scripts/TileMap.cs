using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileMap : MonoBehaviour {

    public GameObject selectedUnit;
    public TileType[] tileTypes;

    int[,] tiles;

    int mapSizeX = 13;
    int mapSizeY = 20;


    // Use this for initialization
    void Start () {

        tiles = new int[mapSizeX, mapSizeY];
		
        for(int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x,y] = 0;
            }

        }

        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;
        tiles[8, 4] = 2;
        GenerateMapVisuals();

    }

    void GenerateMapVisuals()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0.75f), Quaternion.identity);


                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }

        }
    }

    public void MoveSelectedUnitTo(int x, int y)
    {
        selectedUnit.transform.position = new Vector3(x, y, 0);
    }


	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Player")
                {
                    Debug.Log("It's working!");
                    selectedUnit = hitInfo.collider.gameObject;
                    
                }
                else
                {
                    //Debug.Log("nopz");
                }
            }
            else
            {
                //Debug.Log("No hit");
            }
            //Debug.Log("Mouse is down");
        }
    }
}
