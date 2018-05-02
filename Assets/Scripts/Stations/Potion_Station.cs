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
	public List<Image> HoldingImages;
    public GameObject PotionUI;
    public GameObject Work_Item;
	protected bool success;

	// Use this for initialization
	protected override void Start () {
		ingredients = new List<Ingredient> ();
		//HoldingImages = new List<Image> ();
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            attempt_brew();
        }
    }

    public override void Work(ref Ingredient ingredient)
    {
        for (int i = 0; i < 4; i++)
        {
            if (HoldingImages[i].sprite == null)
            {
                HoldingImages[i].sprite = ingredient.sprite;
                HoldingImages[i].enabled = true;
                ingredients.Add(ingredient);
                red += ingredient.red;
                orange += ingredient.orange;
                yellow += ingredient.yellow;
                green += ingredient.green;
                blue += ingredient.blue;
                purple += ingredient.purple;
                return;
            }
        }
    }

	void attempt_brew() {
		// check against recipes
		foreach (Ingredient p in recipes) {
			success = true;

			if (p.red != red) {
				success = false;
			}
			if (p.orange != orange) {
				success = false;
			}
			if (p.orange != orange) {
				success = false;
			}
			if (p.yellow != yellow) {
				success = false;
			}
			if (p.green != green) {
				success = false;
			}
			if (p.blue != blue) {
				success = false;
			}
			if (p.purple != purple) {
				success = false;
			}

			if (success == true) {
                Ingredient tmp = Object.Instantiate(p);
                PlaceInInventory(ref tmp);

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
        ingredients = new List<Ingredient>();
        foreach (Image i in HoldingImages)
        {
            i.sprite = null;
            i.enabled = false;
        }
    }

    public override void StartMode(Inventory inv)
    {
        base.StartMode(inv);
        PotionUI.SetActive(true);
        Work_Item.SetActive(false);
        bar.SetActive(false);
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
        PotionUI.SetActive(false);
        Work_Item.SetActive(true);
        red = 0;
        orange = 0;
        yellow = 0;
        green = 0;
        blue = 0;
        purple = 0;
    }
}
