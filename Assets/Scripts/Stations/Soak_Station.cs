using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soak_Station : Station {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Job(ref Ingredient ingredient) {
        base.Job(ref ingredient);
        // Elemental Interactions
        ingredient.purple += ingredient.red;
		ingredient.red = 0;
		if (ingredient.green > 0) {
			base.Explode ();
		}

		// Physical Interactions
		if (ingredient.form == "powdery") {
			ingredient.form = "pasty";
		}

		if (ingredient.form == "pasty") {
			ingredient.form = "watery";
		}

		if (ingredient.form == "crumbling") {
			ingredient.form = "plastic";
		}

		if (ingredient.form == "plastic") {
			ingredient.form = "leafy";
		}

        if (ingredient.form == "solid")
        {
            ingredient.form = "slippery";
        }

        if (ingredient.form == "slippery")
        {
            ingredient.form = "squishy";
        }
    }
}
