using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Station : Station {

<<<<<<< HEAD
	protected List<Ingredient> ingredients;
	public int red;
	public int orange;
	public int yellow;
	public int green;
	public int blue;
	public int purple;

	// Use this for initialization
	void Start () {
		anchor = new Vector3(3f, 2.4f, -.5f);
        anchorRot = new Vector3(30f, 90f, 0f);
		ingredients = new List<Ingredient> ();
		red = 0;
		orange = 0;
		yellow = 0;
		green = 0;
		blue = 0;
		purple = 0;
=======
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
>>>>>>> 8cfa74ef3d416b96dc251987b3963872f991b00b
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

	Item attempt_brew() {
		// check against recipes

		// reset after success
		red = 0;
		orange = 0;
		yellow = 0;
		green = 0;
		blue = 0;
		purple = 0;
	}
}
