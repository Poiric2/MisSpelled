using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap_Station : Station {

	// Use this for initialization
	void Start () {
        anchor = new Vector3(-3f, 2.4f, -.5f);
        anchorRot = new Vector3(30f, 270f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void Zap(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.orange += ingredient.yellow;
		ingredient.yellow = 0;
		if (ingredient.purple > 0) {
			print ("Explode!");
		}
	}
}
