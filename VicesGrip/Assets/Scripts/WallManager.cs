using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public WallMovement[] walls;

    public void MoveAllWalls()
    {
        foreach (WallMovement wall in walls)
        {
            wall.StartMove();
        }
    }
}
