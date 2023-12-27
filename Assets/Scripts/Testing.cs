using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // reference our grid
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(4, 4, 10f, new Vector3(-5, -3));
    }

    // Update is called once per frame
    void Update()
    {
        // set value of our grid based on where we left click
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }

        // get value of our grid based on where we right click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
