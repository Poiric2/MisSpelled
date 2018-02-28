using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush_Station : Station {

	// Use this for initialization
	void Start () {
        anchor = new Vector3(-3f, 2.4f, -.5f);
        anchorRot = new Vector3(30f, 270f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void Crush(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.red += ingredient.orange;
		ingredient.orange = 0;
		if (ingredient.blue > 0) {
			print ("Explode!");
		}

		// Physical Interactions
		if (ingredient.form == "leafy") {
			ingredient.form = "pasty";
		}

		if (ingredient.form == "dried") {
			ingredient.form = "powdery";
		}

		if (ingredient.form == "frozen") {
			ingredient.form = "shaved";
		}

		if (ingredient.form == "fractured") {
			ingredient.form = "powdery";
		}

		if (ingredient.form == "squishy") {
			ingredient.form = "pasty";
		}

		if (ingredient.form == "brittle") {
			ingredient.form = "powdery";
		}
	}
}
