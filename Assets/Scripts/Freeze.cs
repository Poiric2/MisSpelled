using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {

	void freeze(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.blue += ingredient.purple;
		ingredient.purple = 0;
		if (ingredient.yellow > 0) {
			print("Explode!")
		}

		// Physical Interactions
		if (ingredient.form == "watery") {
			ingredient.form = "frozen";
		}
	}
}
