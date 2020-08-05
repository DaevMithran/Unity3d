using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Generator[] genTiles;
    private int genindex;
    private Generator currTile;
    public static event Action OnCubeGenerated = delegate { };

    private void Awake()
    {
        genTiles = FindObjectsOfType<Generator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Movement.CurrentTile!=null)
                Movement.CurrentTile.Stop();

            genindex = genindex == 1 ? 0 : 1;
            currTile = genTiles[genindex];

            currTile.GenCube();
            OnCubeGenerated();
        }
    }
}
