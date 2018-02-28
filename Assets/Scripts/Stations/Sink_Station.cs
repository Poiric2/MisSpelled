using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink_Station : Station {

	// Use this for initialization
	void Start () {
        anchor = new Vector3(-.5f, 2.4f, -3f);
        anchorRot = new Vector3(30f, 180f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
