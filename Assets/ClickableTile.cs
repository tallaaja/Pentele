using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {


    public int tileX;
    public int tileY;
    public TileMap map;

    private void OnMouseDown()
    {
        Debug.Log("cliskced");

        map.MoveSelectedUnitTo(tileX, tileY);

    }






}
