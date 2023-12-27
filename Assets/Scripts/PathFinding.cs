using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PathFinding
{
    private Grid grid;
    public PathFinding(int width, int height)
    {
        grid = new Grid(width, height, 10f, new Vector3(-80f, -45f));
    }
}
