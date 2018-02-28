using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : MonoBehaviour {

	void zap(ref Ingredient ingredient) {

		// Elemental Interactions
		ingredient.orange += ingredient.yellow;
		ingredient.yellow = 0;
		if (ingredient.purple > 0) {
			print ("Explode!");
		}
	}
}
