using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 14f;
    public float interactDistance = 5f;
    RaycastHit hit;

    private bool canMove = true;
    private CameraLook camLook;
    private bool canInteract = true;
    private Inventory inventory;
    private Station currStation;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        camLook = GetComponentInChildren<CameraLook>();
        inventory = GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {

        if (canMove){
            float forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            transform.Translate(strafe, 0, forward);
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
                }
                else
                {
                    inventory.UnPrime(i);
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
                currStation = hit.transform.gameObject.GetComponent<Station>();
                camLook.StartLerp(currStation.anchor, currStation.anchorRot, currStation.anchorCharRot);
                currStation.StartMode(inventory);
            }
            else if(hit.transform.tag == "pickup")
            {
                inventory.Add(hit.transform.GetComponent<Pickup>().item);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
