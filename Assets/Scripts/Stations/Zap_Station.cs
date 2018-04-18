using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap_Station : Station {

	// Use this for initialization
	protected override void Start () {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {
		base.Update();
	}

    public override void Job(ref Ingredient ingredient) {
        base.Job(ref ingredient);
        // Elemental Interactions
        ingredient.red += ingredient.orange;
		ingredient.orange = 0;
		if (ingredient.blue > 0) {
			base.Explode ();
		}

        // Destructive Interactions
        if (ingredient.destruction == "pure")
        {
            ingredient.destruction = "shocked";
        }

        if (ingredient.destruction == "frozen")
        {
            ingredient.destruction = "desolated";
        }

        if (ingredient.destruction == "burnt")
        {
            ingredient.destruction = "smote";
        }
    }
}
