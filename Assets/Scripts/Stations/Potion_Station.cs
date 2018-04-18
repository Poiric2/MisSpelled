using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion_Station : Station {

	protected List<Ingredient> ingredients;
	public int red = 0;
    public int orange = 0;
    public int yellow = 0;
    public int green = 0;
    public int blue = 0;
    public int purple = 0;

    public List<Potion> Potions;
    public Image[] HoldingImages;
    public GameObject PotionUI;

    // Use this for initialization
    protected override void Start () {
        base.Start();
		ingredients = new List<Ingredient> ();
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

    public override void Work(ref Ingredient ingredient)
    {
        if (Input.GetKeyDown(KeyCode.V))
            attempt_brew();
    }

	void attempt_brew() {
        // check against recipes
        foreach (Potion p in Potions)
        {
            if (red == p.red &&
               orange == p.orange &&
               yellow == p.yellow &&
               green == p.green &&
               blue == p.blue &&
               purple == p.purple)
            {
                ingredients = new List<Ingredient>();
                inventory.Add(p);
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
        PotionUI.SetActive(true);
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
    }
}
