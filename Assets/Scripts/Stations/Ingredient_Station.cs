using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient_Station : Station {

    public GameObject work_UI;

	// Use this for initialization
	protected override void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {
        for (int i = 0; i < 4; i++)
        {
            if (Input.mousePosition.x > station_items[i].transform.position.x - 32 &&
               Input.mousePosition.x < station_items[i].transform.position.x + 32 &&
               Input.mousePosition.y > station_items[i].transform.position.y - 32 &&
               Input.mousePosition.y < station_items[i].transform.position.y + 32)
            {
                Prime(i);
                if (Input.GetMouseButtonDown(0) && items[i] != null)
                {
                    Drag(i);
                    dragging = true;
                }
            }
            else
            {
                UnPrime(i);
            }
        }

        if (Input.GetMouseButtonUp(0) && dragging && operated)
        {
            if (dragPrimed)
            {
                if (dragUI.transform.position.x > inventoryhitbox.transform.position.x - 128 &&
               dragUI.transform.position.x < inventoryhitbox.transform.position.x + 128 &&
               dragUI.transform.position.y > inventoryhitbox.transform.position.y - 128 &&
               dragUI.transform.position.y < inventoryhitbox.transform.position.y + 161)
                {
                    inventory.AddNewItem(selected);
                }
            }
            UnDrag();
            dragging = false;
        }

        if (dragging && operated)
        {
            dragUI.transform.position = Input.mousePosition;
            if (dragUI.transform.position.x > inventoryhitbox.transform.position.x - 128 &&
               dragUI.transform.position.x < inventoryhitbox.transform.position.x + 128 &&
               dragUI.transform.position.y > inventoryhitbox.transform.position.y - 128 &&
               dragUI.transform.position.y < inventoryhitbox.transform.position.y + 161)
            {
                PrimeDrag();
            }
            else
            {
                UnPrimeDrag();
            }
        }
    }

    public override void StartMode(Inventory inv)
    {
        Cursor.lockState = CursorLockMode.None;
        inventory = inv;
        working = true;
        title.text = st_name;
        dsc.text = description;
        InitInventory();
        StationUI.SetActive(true);
        inventory.Display();
        ingredient = null;
        operated = true;
        work_UI.SetActive(false);
    }

    public override void EndMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        working = false;
        StationUI.SetActive(false);
        inventory.Hide();
        operated = false;
        work_UI.SetActive(true);
    }
}
