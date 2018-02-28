using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

    public Vector3 anchor;
    public Vector3 anchorRot;

    protected Ingredient ingredient;
    protected Inventory inventory;

    bool working = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (working)
            Work();
	}

    public virtual void StartMode(Inventory inv){
        Cursor.lockState = CursorLockMode.None;
        inventory = inv;
        working = true;
    }

    protected virtual void Work()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.items[0]!= null)
        {
            ingredient = (Ingredient)inventory.items[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.items[1] != null)
        {
            ingredient = (Ingredient)inventory.items[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.items[2] != null)
        {
            ingredient = (Ingredient)inventory.items[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && inventory.items[3] != null)
        {
            ingredient = (Ingredient)inventory.items[3];
        }
    }

    public virtual void EndMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        working = false;
    }

	protected void Explode() {
		print ("Explode!");
	}
}
