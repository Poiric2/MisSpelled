﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 14f;
    public float interactDistance = 5f;
    RaycastHit hit;

    private bool canMove = true;
    private CameraLook camLook;
    private bool canInteract = true;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        camLook = GetComponentInChildren<CameraLook>();
    }
	
	// Update is called once per frame
	void Update () {

        if (canMove){
            float forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            transform.Translate(strafe, 0, forward);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SwapMovementState();

        if (Input.GetKeyDown(KeyCode.E) && canInteract)
            Interact();
	}

    void SwapMovementState(){
       canMove = !canMove;
       camLook.canLook = !camLook.canLook;
       canInteract = !canInteract;
    }

    void Interact(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactDistance)){
            if (hit.transform.tag == "interactable"){
                print("interact");
                SwapMovementState();
                camLook.anchor = new Vector3(3f,2.4f,-.5f);
                camLook.anchorRot = new Vector3(30f, 90f, 0f);
                camLook.camPos = Camera.main.transform.position;
                transform.position = new Vector3(3f, 1.5f, -.5f);
                }
        }
    }
}
