using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Station : MonoBehaviour {

    public Vector3 anchor;
    public Vector3 rotVals;
    public Quaternion anchorRot;
    public Quaternion anchorCharRot;

    protected Ingredient ingredient;
    protected Inventory inventory;

    bool working = false;

    public string st_name;
    public string description;

    public GameObject StationUI;
    public Text title;
    public Text dsc;

    // Use this for initialization
    protected virtual void Start () {
        anchorRot = Quaternion.Euler(rotVals.x,0f,0f);
        anchorCharRot = Quaternion.Euler(0f, rotVals.y, 0f);
        print(anchorRot);
        print(anchorCharRot);
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
        title.text = st_name;
        dsc.text = description;
        StationUI.SetActive(true);
        inventory.Display();
    }

    protected virtual void Work()
    {
        for(int i = 0; i < Inventory.inventorySize; i++)
        {
            if (Input.GetMouseButtonDown(0) && inventory.items[i] != null && inventory.primes[i].enabled)
            {
                ingredient = (Ingredient)inventory.items[i];
                inventory.Highlight(i);
            }
        }
    }

    public virtual void EndMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        working = false;
        StationUI.SetActive(false);
        inventory.Clear();
        inventory.Hide();
    }

	protected void Explode() {
		print ("Explode!");
	}
}
