using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auximus : Station {

    public List<Ingredient> keyPotions;
    public List<Ingredient> currPotions;

    public GameObject column;

    private bool newPotion = false;
    private bool End = false;

    protected override void Update()
    {
        base.Update();
        if(working_item != null)
        {
            foreach (Ingredient p in keyPotions)
            {
                if (working_item.name == p.name)
                {
                    newPotion = true;
                    foreach (Ingredient c in currPotions)
                    {
                        if(c != null)
                        {
                            if (c.name == p.name)
                            {
                                newPotion = false;
                            }
                        }
                    }
                    if (newPotion)
                    {
                        source.Play();
                        for (int i = 0; i < 12; i++)
                        {
                            if (currPotions[i] == null)
                            {
                                currPotions[i] = (Ingredient)working_item;
                                break;
                            }
                        }
                        working_item = null;
                        working_image.sprite = null;
                        working_image.enabled = false;
                        newPotion = false;
                    }
                }
            }
        }

        End = true;
        foreach(Ingredient p in currPotions)
        {
            if (p == null)
                End = false;
        }
        if (End)
            EndState();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Work(ref Ingredient ingredient)
    {
        working_item = ingredient;
        working_image.sprite = ingredient.sprite;
        working_image.enabled = true;
    }

    public override void StartMode(Inventory inv)
    {
        base.StartMode(inv);
        bar.SetActive(false);
        column.SetActive(false);
    }

    public override void EndMode()
    {
        base.EndMode();
        if(working_item != null)
        {
            inventory.Add(working_item);
            working_item = null;
            working_image.enabled = false;
        }
        column.SetActive(true);
    }

    private void EndState()
    {
        SceneManager.LoadScene("Epilogue");
    }
}
