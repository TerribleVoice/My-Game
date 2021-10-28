using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int Size;

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = new Color(0.48f, 0.88f, 0.51f, 0.5f);
    //     for (var x = 0; x < Size.x; x++)
    //     {
    //         for (var y = 0; y < Size.y; y++)
    //         {
    //             var newX = -Size.x / 2 + x;
    //             var newY = -Size.y / 2 + y;
    //
    //             Gizmos.DrawCube(transform.position + new Vector3(newX, 0, newY), new Vector3(1, 0.1f, 1));
    //         }
    //     }
    // }
}
