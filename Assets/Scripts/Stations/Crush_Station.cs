using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush_Station : Station {

	// Use this for initialization
	override protected void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
	}

    public override void  Job(ref Ingredient ingredient) {
        base.Job(ref ingredient);
        // Elemental Interactions
        ingredient.orange += ingredient.yellow;
		ingredient.yellow = 0;
		if (ingredient.purple > 0) {
			base.Explode ();
		}

        // Physical Interactions
        if (ingredient.form == "solid")
        {
            ingredient.form = "crumbling";
        }

        if (ingredient.form == "crumbling")
        {
            ingredient.form = "powdery";
        }

        if (ingredient.form == "slippery")
        {
            ingredient.form = "plastic";
        }

        if (ingredient.form == "plastic")
        {
            ingredient.form = "pasty";
        }

        if (ingredient.form == "squishy")
        {
            ingredient.form = "leafy";
        }

        if (ingredient.form == "leafy")
        {
            ingredient.form = "watery";
        }
    }

    public override void StartMode(Inventory inv)
    {
        base.StartMode(inv);
    }

    protected override void Work()
    {
        base.Work();
    }

    public override void EndMode()
    {
        base.EndMode();
    }
}
