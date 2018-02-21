using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {

	void freeze(ref Ingredient ingredient) {
		if (ingredient.form == "watery") {
			ingredient.form = "frozen";
		}
	}
}
