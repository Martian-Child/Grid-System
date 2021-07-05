/*
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MartianChild.GridSystem.Pathfinder;
using MartianChild.Utility;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AStarTest : MonoBehaviour
{
    private AStarPathfinder _pathfinder;
    private Raycaster _raycaster = new Raycaster();
    public GridManager grid;
    private List<PathNode> path;

    private void Start()
    {
        _pathfinder = new AStarPathfinder(grid.GetGrid());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("TESTING");
            path = _pathfinder.FindPath(Vector3.zero, new Vector3(2, 3, 4));
            Debug.Log("Mouse Click Pos: " + new Vector3(2, 3, 4));
            Debug.Log("Path Count: " + path.Count);
            if (path != null)
            {
                Debug.Log("Drawing Path");
                for(int node = 0; node < path.Count; node++)
                {
                    Debug.DrawLine(path[node].gridPosition, path[node + 1].gridPosition);
                }
            }
        }
    }
}
*/
