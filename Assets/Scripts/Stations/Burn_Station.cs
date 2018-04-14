using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn_Station : Station {

	// Use this for initialization
	protected override void Start () {
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
		ingredient.yellow += ingredient.green;
		ingredient.green = 0;
		if (ingredient.red > 0) {
			base.Explode ();
		}

        // Destructive Interactions
        if (ingredient.destruction == "pure")
        {
            ingredient.destruction = "burnt";
        }

        if (ingredient.destruction == "frozen")
        {
            ingredient.destruction = "freezerburnt";
        }

        if (ingredient.destruction == "shocked")
        {
            ingredient.destruction = "smote";
        }
    }
}
