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
        grid = new Grid(16, 9, 10f, new Vector3(-80f, -45f));
    }

    private void Update()
    {
        // left click
        HandleClickToModifyGrid();

        // log value when right click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

    // add value when left click
    private void HandleClickToModifyGrid()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.ReverseValue(UtilsClass.GetMouseWorldPosition());
        }
    }
}
