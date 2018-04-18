using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Station : Station {

	protected List<Ingredient> ingredients;
	public int red;
	public int orange;
	public int yellow;
	public int green;
	public int blue;
	public int purple;

	public List<Recipe> recipes;
	protected bool success;

	// Use this for initialization
	protected override void Start () {
		ingredients = new List<Ingredient> ();
		red = 0;
		orange = 0;
		yellow = 0;
		green = 0;
		blue = 0;
		purple = 0;
		success = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
		attempt_brew ();
        base.Update();
    }

	void add_ingredient(Ingredient ingredient) {
		ingredients.Add (ingredient);
		red += ingredient.red;
		orange += ingredient.orange;
		yellow += ingredient.yellow;
		green += ingredient.green;
		blue += ingredient.blue;
		purple += ingredient.purple;
	}

	Recipe brew_potion(Recipe recipe) {
		return recipe;
	}

	void attempt_brew() {
		// check against recipes
		foreach (Recipe recipe in recipes) {
			success = true;

			if (recipe.red != red) {
				success = false;
			}
			if (recipe.orange != orange) {
				success = false;
			}
			if (recipe.orange != orange) {
				success = false;
			}
			if (recipe.yellow != yellow) {
				success = false;
			}
			if (recipe.green != green) {
				success = false;
			}
			if (recipe.blue != blue) {
				success = false;
			}
			if (recipe.purple != purple) {
				success = false;
			}

			if (success == true) {
				brew_potion (recipe);

				red = 0;
				orange = 0;
				yellow = 0;
				green = 0;
				blue = 0;
				purple = 0;
			}
		}

		if (success == false) {
			if (recipes.Count > 5) {
				print("potion failed");
				red = 0;
				orange = 0;
				yellow = 0;
				green = 0;
				blue = 0;
				purple = 0;
			}
		}
	}
}
