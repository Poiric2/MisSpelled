using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour {

	void burn(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.yellow += ingredient.green;
		ingredient.green = 0;
		if (ingredient.red > 0) {
			print("Explode!")
		}
		
		// Physical Interactions
		if (ingredient.form == "leafy") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "dried") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "pasty") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "watery") {
			ingredient.form = "boiled";
		}

		if (ingredient.form == "powdery") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "frozen") {
			ingredient.form = "watery";
		}

		if (ingredient.form == "fractured") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "squishy") {
			ingredient.form = "burnt";
		}

		if (ingredient.form == "brittle") {
			ingredient.form = "burnt";
		}
	}
}
