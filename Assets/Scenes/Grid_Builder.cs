using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Grid_builder : MonoBehaviour
{
    public GameObject cube;
    public int[,] gridArray;
    private GameObject[] cubeArray;
    private int width;
    private int height;
    private int gridCounter = 0;
    private int startPossition =  3;
    private int endPossition = 45;
    private int[] impassable = {11, 13, 17};

    public void Start()
    {
        
        this.width = 7;
        this.height = 7;

        gridArray = new int[width, height];
        cubeArray = new GameObject[width * height];
        Debug.Log(cubeArray.Length);

        for (int x = 0; x< gridArray.GetLength(0); x++)
        {
            for (int y = 0; y< gridArray.GetLength(1); y++)
            {
                CubeSpawner(x,y);
                
                StartCoroutine(waitTimer());
            }
        }

    }

    public void CubeSpawner(int x, int y)
    {
        cubeArray[gridCounter] = Instantiate(cube, new Vector3(x, 0, y), transform.rotation);
        var cubeRenderer = cubeArray[gridCounter].GetComponent<Renderer>();
        if (gridCounter == startPossition)
        {
            Debug.Log(x + "," + y);
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }
        if (gridCounter == endPossition)
        {
            Debug.Log(x + "," + y);
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
        if (gridCounter == impassable[0] || gridCounter == impassable[1]|| gridCounter == impassable[2])
        {
            Debug.Log(x + "," + y);
            cubeRenderer.material.SetColor("_Color", Color.red);
        }


        gridCounter ++ ;

        
    }

    IEnumerator waitTimer()
    {
        yield return new WaitForSeconds(1);
    }



}
