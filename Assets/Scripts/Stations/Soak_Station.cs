using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soak_Station : Station {

	// Use this for initialization
	void Start () {
        anchor = new Vector3(-.5f, 2.4f, -3f);
        anchorRot = new Vector3(30f, 180f, 0f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void Soak(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.purple += ingredient.red;
		ingredient.red = 0;
		if (ingredient.green > 0) {
			base.Explode ();
		}

		// Physical Interactions
		if (ingredient.form == "pasty") {
			ingredient.form = "watery";
		}

		if (ingredient.form == "powdery") {
			ingredient.form = "watery";
		}

		if (ingredient.form == "brittle") {
			ingredient.form = "squishy";
		}

		if (ingredient.form == "burnt") {
			ingredient.form = "murky";
		}
	}
}
