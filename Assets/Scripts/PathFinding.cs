using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathFinding
{
    // TODO: import grid into here, create the node list by using the grid values to decide which is walkable, set neighbours accordingly
    // Will need to set events to be able to change map and reset pathfinding and stuff

    // performs the pathfinding given a start node and a target node
    public static List<PathNode> FindPath(PathNode startNode, PathNode targetNode)
    {
        // a list containing the nodes we need to process, and the ones we already have
        List<PathNode> toSearch = new List<PathNode>() { startNode };
        List<PathNode> processed = new List<PathNode>();

        // keep performing the search until no more nodes remain
        // nodes can get readded to the search list
        while (toSearch.Any())
        {
            // find which node in the list has the lowest f-cost, this will be the node we check from
            PathNode current = toSearch[0];
            foreach (PathNode node in toSearch)
            {
                if (node.F < current.F || node.F == current.F && node.H < current.H)
                {
                    current = node;
                }
            }
            // we have now processed this node
            processed.Add(current);
            toSearch.Remove(current);

            // now check if the current node is the target
            if (current == targetNode)
            {
                // start retracing the path by starting at target
                PathNode currentPathTile = targetNode;
                List<PathNode> path = new List<PathNode>();
                // then keep looping until we reach the start again
                while (currentPathTile != startNode)
                {
                    // add this tile to the path and then set to its connection
                    path.Add(currentPathTile);
                    currentPathTile = currentPathTile.Connection;
                }
            }


            foreach (PathNode neighbour in current.Neighbours.Where(node => node.Walkable && !processed.Contains(node))
            {
                // TODO: finish tarodev video
            }
        }
    }
}
