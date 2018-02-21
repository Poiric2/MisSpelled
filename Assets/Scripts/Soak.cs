using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soak : MonoBehaviour {

	void soak(ref Ingredient ingredient) {
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
