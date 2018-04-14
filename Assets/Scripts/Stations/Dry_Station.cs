using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dry_Station : Station {

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
		ingredient.green += ingredient.blue;
		ingredient.blue = 0;
		if (ingredient.orange > 0) {
			base.Explode ();
		}

        // Physical Interactions
        if (ingredient.form == "pasty")
        {
            ingredient.form = "powdery";
        }

        if (ingredient.form == "watery")
        {
            ingredient.form = "pasty";
        }

        if (ingredient.form == "plastic")
        {
            ingredient.form = "crumbling";
        }

        if (ingredient.form == "leafy")
        {
            ingredient.form = "plastic";
        }

        if (ingredient.form == "slippery")
        {
            ingredient.form = "solid";
        }

        if (ingredient.form == "squishy")
        {
            ingredient.form = "slippery";
        }
    }
}
