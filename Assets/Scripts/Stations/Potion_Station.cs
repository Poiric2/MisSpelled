using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion_Station : Station {

	protected List<Ingredient> ingredients;
	public int red;
	public int orange;
	public int yellow;
	public int green;
	public int blue;
	public int purple;

	public List<Ingredient> recipes;
	protected List<Image> HoldingImages;
	protected bool success;

	// Use this for initialization
	protected override void Start () {
		ingredients = new List<Ingredient> ();
		HoldingImages = new List<Image> ();
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
        base.Update();
    }

    public override void Job(ref Ingredient ingredient) {
        foreach(Ingredient e in ingredients)
        {
            if(e == ingredient)
            {
                return;
            }
        }
		ingredients.Add (ingredient);
        for(int i = 0; i < 4; i++)
        {
            if(HoldingImages[i].sprite == null)
            {
                HoldingImages[i].sprite = ingredient.sprite;
                HoldingImages[i].enabled = true;
                break;
            }
        }
        //inventory.Remove(ingredient);
		red += ingredient.red;
		orange += ingredient.orange;
		yellow += ingredient.yellow;
		green += ingredient.green;
		blue += ingredient.blue;
		purple += ingredient.purple;
	}

	Ingredient brew_potion(Ingredient recipe) {
		return recipe;
	}

	void attempt_brew() {
		// check against recipes
		foreach (Ingredient recipe in recipes) {
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

    public override void StartMode(Inventory inv)
    {
        base.StartMode(inv);
        // PotionUI.SetActive(true);
    }

    public override void EndMode()
    {
        base.EndMode();
        foreach (Ingredient e in ingredients)
            inventory.Add(e);
        ingredients = new List<Ingredient>();
        foreach (Image image in HoldingImages)
        {
            image.sprite = null;
            image.enabled = false;
        }
        // PotionUI.SetActive(false);
    }
}
