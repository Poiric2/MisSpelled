using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Image[] images = new Image[4];
    public Item[] items = new Item[4];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(Item x){
        for (int i = 0; i < 4; i++){
            if(items[i] == null){
                items[i] = x;
                images[i].sprite = x.sprite;
                images[i].enabled = true;
                return;
            }
        }
    }

    public void Remove(Item x)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i] == x)
            {
                items[i] = null;
                images[i].sprite = null;
                images[i].enabled = false;
                //UpdateInventory();
                return;
            }
        }
    }

    void UpdateInventory()
    {
        for(int i = 0; i < 3; i++)
        {
            if(items[i] == null && items[i+1] != null)
            {
                items[i] = items[i + 1];
                images[i] = images[i + 1];
                images[i].enabled = true;
                items[i + 1] = null;
                images[i + 1] = null;
                images[i + 1].enabled = false;
            }
        }
    }
}
