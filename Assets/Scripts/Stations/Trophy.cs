﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Station {

    bool a;
    bool b;
    bool c;
    bool d;

	public List<Ingredient> potions;

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        if(a && b && c && d)
        {
            dsc.text = "You've created all the potions!";
        }
	}

    public override void Work(ref Ingredient ingredient)
    {
        foreach(Ingredient i in inventory.items)
        {
            if (i == potions[0])
                a = true;
            if (i == potions[1])
                b = true;
            if (i == potions[2])
                c = true;
            if (i == potions[3])
                d = true;
        }
    }
}
