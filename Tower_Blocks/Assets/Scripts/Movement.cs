using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public static Movement CurrentTile { get; private set; }
    public static Movement lastTile { get; private set; }
    public MoveDirection MoveDirection { get; set; }
    public float moveSpeed =1f;

    public void OnEnable()
    {   if (lastTile == null)
            lastTile = GameObject.Find("Block").GetComponent<Movement>();

        CurrentTile = this;
        GetComponent<Renderer>().material.color = GetRandomColor();

            transform.localScale = new Vector3(lastTile.transform.localScale.x, transform.localScale.y, lastTile.transform.localScale.z);
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float remain;
        float direction;
        if (MoveDirection == MoveDirection.Z)
        {
            remain = transform.position.z - lastTile.transform.position.z;
            if (Mathf.Abs(remain) >= lastTile.transform.localScale.z)
            {
                lastTile = null;
                CurrentTile = null;
                SceneManager.LoadScene(0);
            }
            direction = remain > 0 ? 1f : -1f;
            SplitCubeOnZ(remain, direction);
        }
        else
        {
            remain = transform.position.x - lastTile.transform.position.x;

            if (Mathf.Abs(remain) >= lastTile.transform.localScale.x)
            {
                lastTile = null;
                CurrentTile = null;
                SceneManager.LoadScene(0);
            }
            direction = remain > 0 ? 1f : -1f;
            SplitCubeOnX(remain, direction);
        }
    }

    private void SplitCubeOnX(float remain, float direction)
    {
        float newXsize = lastTile.transform.localScale.x - Mathf.Abs(remain);
        float fallBlocksize = transform.localScale.x - newXsize;

        Debug.Log(newXsize);
        float newXposition = lastTile.transform.position.x + (remain / 2);
        transform.localScale = new Vector3(newXsize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXposition, transform.position.y, transform.position.z);
        lastTile = this;
        float fallingCube = transform.position.x + (newXsize / 2f * direction);
        float fallingBlockXposition = fallingCube + (fallBlocksize / 2f * direction);
        CreateCube(fallingBlockXposition, fallBlocksize);
    }

    private void SplitCubeOnZ(float remain,float direction)
    {
        float newZsize = lastTile.transform.localScale.z - Mathf.Abs(remain);
        float fallBlocksize = transform.localScale.z - newZsize;
 
        Debug.Log(newZsize);
        float newZposition = lastTile.transform.position.z + (remain / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZsize);
        transform.position = new Vector3(transform.position.x,transform.position.y,newZposition);
        lastTile = this;
        float fallingCube = transform.position.z + (newZsize / 2f * direction);
        float fallingBlockZposition = fallingCube + (fallBlocksize / 2f *direction);
        CreateCube(fallingBlockZposition, fallBlocksize);
    }

    private void CreateCube(float fallingBlockposition,float fallBlocksize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if (MoveDirection == MoveDirection.Z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallBlocksize);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockposition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallBlocksize, transform.localScale.y,transform.localScale.z);
            cube.transform.position = new Vector3( fallingBlockposition, transform.position.y,transform.position.z);

        }
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        cube.AddComponent<Rigidbody>();
        Destroy(cube.gameObject, 0.5f);
    }

    private void Update()
    {   
        if(MoveDirection == MoveDirection.Z)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        else
            transform.position += transform.right * Time.deltaTime * moveSpeed;
    }

 }
