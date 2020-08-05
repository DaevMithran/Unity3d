using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Movement cubePrefab;
    public MoveDirection dir;

    public void GenCube()
    {
        var cube = Instantiate(cubePrefab);
        if (Movement.lastTile != null && Movement.lastTile.gameObject != GameObject.Find("Block"))
        {
            float x = dir == MoveDirection.X ? transform.position.x : Movement.lastTile.transform.position.x;
            float z = dir == MoveDirection.Z ? transform.position.z : Movement.lastTile.transform.position.z;
            cube.transform.position = new Vector3(x,
                                             Movement.lastTile.transform.position.y + cubePrefab.transform.localScale.y,
                                             z);
        }
        else
        {
            cube.transform.position = transform.position;
        }

        cube.MoveDirection = dir;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
}
