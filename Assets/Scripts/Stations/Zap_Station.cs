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

    protected override void Job(ref Ingredient ingredient) {
        // Elemental Interactions
        ingredient.orange += ingredient.yellow;
		ingredient.yellow = 0;
		if (ingredient.purple > 0) {
			base.Explode ();
		}
	}
}
