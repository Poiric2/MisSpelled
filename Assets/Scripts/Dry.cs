﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dry : MonoBehaviour {

	void dry(ref Ingredient ingredient) {
		if (ingredient.form == "leaf") {
			ingredient.form = "dried";
		}

		if (ingredient.form == "pasty") {
			ingredient.form = "powdery";
		}

		if (ingredient.form == "watery") {
			ingredient.form = "powdery";
		}

		if (ingredient.form == "squishy") {
			ingredient.form = "brittle";
		}

		if (ingredient.form == "murky") {
			ingredient.form = "burnt";
		}
	}
}
