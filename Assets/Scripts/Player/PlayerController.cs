﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class PlayerController : MonoBehaviour {

    public float speed = 14f;
    public float interactDistance = 5f;

    private bool canMove = true;
    private bool canInteract = true;

    private CameraLook camLook;

    private Inventory inventory;
    private Station currStation;

    public GameObject dragUI;
    public GameObject StationHitbox;
    private bool dragging = false;

    private Ray outlineRay;
    private List<Outline> currOutlines;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        camLook = GetComponentInChildren<CameraLook>();
        inventory = GetComponent<Inventory>();
        currOutlines = new List<Outline>();
    }
	
	// Update is called once per frame
	void Update () {

        if (canMove)
        {
            float forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            transform.Translate(strafe, 0, forward);

            outlineRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if ( Physics.Raycast(outlineRay, out hit, interactDistance))
            {
                PaintOutline();
            }
            else
            {
                ClearOutline();
            }
        }
        if (Input.GetKeyDown(KeyCode.L) && !canInteract)
            SwapMovementState();

        if (Input.GetKeyDown(KeyCode.E) && canInteract)
            Interact();

        if (Input.GetKeyDown(KeyCode.I))
            inventory.Switch();

        if (inventory.open)
            for (int i = 0; i < Inventory.inventorySize; i++)
            {
                if (Input.mousePosition.x > inventory.images[i].transform.position.x - 32 &&
                   Input.mousePosition.x < inventory.images[i].transform.position.x + 32 &&
                   Input.mousePosition.y > inventory.images[i].transform.position.y - 32 &&
                   Input.mousePosition.y < inventory.images[i].transform.position.y + 32)
                {
                    inventory.Prime(i);
                    if (Input.GetMouseButtonDown(0) && inventory.items[i] != null)
                    {
                        inventory.Drag(i);
                        dragging = true;
                    }
                }
                else
                {
                    inventory.UnPrime(i);
                }
            }

        if (Input.GetMouseButtonUp(0) && dragging)
        {
            if (inventory.dragPrimed)
            {
                Ingredient tmp = (Ingredient)inventory.selected;
                currStation.Job(ref tmp);
            }
            inventory.UnDrag();
            dragging = false;
        }

        if (dragging)
        {
            dragUI.transform.position = Input.mousePosition;
            if(dragUI.transform.position.x > StationHitbox.transform.position.x &&
               dragUI.transform.position.x < StationHitbox.transform.position.x + 300 &&
               dragUI.transform.position.y > StationHitbox.transform.position.y &&
               dragUI.transform.position.y < StationHitbox.transform.position.y + 200)
            {
                inventory.PrimeDrag();
            }
            else
            {
                inventory.UnPrimeDrag();
            }
        }
    }

    void SwapMovementState(){
       canMove = !canMove;
       canInteract = !canInteract;
       if (camLook.canLook == false)
         camLook.EndLerp();
       if (currStation != null) {
         currStation.EndMode();
         currStation = null;
       }
    }

    void Interact(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactDistance)){
            if (hit.transform.tag == "interactable"){
                SwapMovementState();
                ClearOutline();
                currStation = hit.transform.gameObject.GetComponent<Station>();
                camLook.StartLerp(currStation.anchor, currStation.anchorRot, currStation.anchorCharRot);
                currStation.StartMode(inventory);
            }
            else if(hit.transform.tag == "pickup")
            {
                inventory.AddNewItem(hit.transform.GetComponent<Pickup>().item);
                ClearOutline();
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void PaintOutline()
    {
        currOutlines.AddRange(hit.transform.gameObject.GetComponentsInChildren<Outline>());
        
        foreach (Outline o in currOutlines)
        {
            o.enabled = true;
        }
    }

    void ClearOutline()
    {
        if (currOutlines.Count != 0)
            foreach (Outline o in currOutlines)
            {
                o.enabled = false;
            }
        currOutlines.Clear();
    }
}
