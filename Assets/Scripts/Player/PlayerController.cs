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

        if (Input.GetKeyDown(KeyCode.L))
            SwapMovementState();

        if (Input.GetKeyDown(KeyCode.E) && canInteract)
            Interact();
	}

    void SwapMovementState(){
       canMove = !canMove;
       canInteract = !canInteract;
       if (camLook.canLook == false)
         camLook.EndLerp();
    }

    void Interact(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactDistance)){
            if (hit.transform.tag == "interactable"){
                SwapMovementState();
                Station station = hit.transform.gameObject.GetComponent<Station>();
                camLook.StartLerp(station.anchor, station.anchorRot);
                station.StartMode();
            }
            else if(hit.transform.tag == "pickup")
            {
                inventory.Add(hit.transform.GetComponent<Pickup>().ingredient);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
