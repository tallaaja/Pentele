using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THe hex class defines the grid position, world space position, size,
/// neighbours, etc... of a hex tile. However,
/// it does NOT interact with UNity dierectly in any way.
/// </summary>
public class Hex{


    public Hex(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }


    //Q + R + S = 0
    //Eli
    // S = -(Q + R)

    public readonly int Q; // column
    public readonly int R; //row
    public readonly int S;

    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;
    float radius = 1f;

    /// <summary>
    /// returns world-space position of this hex
    /// </summary>
    /// <returns></returns>
    public Vector3 Position()
    {
        float height = radius * 2;
        float width = WIDTH_MULTIPLIER * height;

        float vert = height * 0.75f;
        float horiz = width;


        return new Vector3(HexHorizontalSpacing() *(this.R + this.Q/2f),  HexVerticalSpacing() * this.Q, 0);
    }

    public float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f;
    }

    public float HexHorizontalSpacing()
    {
        return HexWidth();
    }

    public float HexHeight()
    {
        return radius * 2;
    }

    public float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }


}
