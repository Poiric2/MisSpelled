using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soak : MonoBehaviour {

	void soak(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.purple += ingredient.red;
		ingredient.red = 0;
		if (ingredient.green > 0) {
			print("Explode!")
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
