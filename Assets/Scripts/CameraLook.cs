﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    private Vector2 mouseLook;
    private Vector2 smoothV;

    public bool canLook = true;
    public float sensitivity = 5.0f;
    public float smooth = 2.0f;
    public float anchorLerpSpeed = .05f;
    public Vector3 camPos;
    public Vector3 anchor;
    public Vector3 anchorRot;

    GameObject character;

    // Use this for initialization
    void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (canLook){
            Look();
        }
        else{
            LerpToAnchor();
        }
    }

    void Look(){
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smooth, sensitivity * smooth));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smooth);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smooth);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);


        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }

    void LerpToAnchor(){
        mouseLook.y = Mathf.Lerp(mouseLook.y, anchorRot.x, anchorLerpSpeed);
        mouseLook.x = Mathf.Lerp(mouseLook.x, anchorRot.y, anchorLerpSpeed);

       camPos.x = Mathf.Lerp(camPos.x, anchor.x, anchorLerpSpeed);
       camPos.y = Mathf.Lerp(camPos.y, anchor.y, anchorLerpSpeed);
       camPos.z = Mathf.Lerp(camPos.z, anchor.z, anchorLerpSpeed);

        transform.localRotation = Quaternion.Euler(mouseLook.y, 0f,0f);
        character.transform.localRotation = Quaternion.Euler(0f,mouseLook.x,0f);

        transform.position = new Vector3(camPos.x,camPos.y,camPos.z);
    }
}