﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush_Station : Station {

	// Use this for initialization
	override protected void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
	}

	void Crush(ref Ingredient ingredient) {
        print(ingredient.red + ":" + ingredient.orange);
		// Elemental Interactions
		ingredient.red += ingredient.orange;
		ingredient.orange = 0;
		if (ingredient.blue > 0) {
			base.Explode ();
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

    public override void StartMode(Inventory inv)
    {
        base.StartMode(inv);
    }

    protected override void Work()
    {
        base.Work();
        if (Input.GetKeyDown(KeyCode.C))
            Crush(ref ingredient);
    }

    public override void EndMode()
    {
        base.EndMode();
    }
}
