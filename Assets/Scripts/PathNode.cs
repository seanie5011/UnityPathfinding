using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathNode
{
    // the nodes next to this node
    public List<PathNode> Neighbours { get; protected set; }
    // the node connected to this node in path
    public PathNode Connection { get; private set; }
    // various costs
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H;
    // whether this node is usable (could be a wall)
    public bool Walkable { get; private set; }

    // setters
    public void SetConnection(PathNode pathNode) => Connection = pathNode;
    public void SetG(float g) => G = g;
    public void SetH(float h) => H = h;
}
