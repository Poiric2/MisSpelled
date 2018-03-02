using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int inventorySize = 16;
    public GameObject InvDisp;

    public Image[] images = new Image[inventorySize];
    public Image[] highlights = new Image[inventorySize];
    public Image[] primes = new Image[inventorySize];
    public Item[] items = new Item[inventorySize];

    int currHighlight = 0;
    public bool open = false;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Add(Item x){
        for (int i = 0; i < inventorySize; i++){
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
        for (int i = 0; i < inventorySize; i++)
        {
            if (items[i] == x)
            {
                items[i] = null;
                images[i].sprite = null;
                images[i].enabled = false;
                highlights[i].enabled = false;
                UpdateInventory();
                return;
            }
        }
    }

    void UpdateInventory()
    {
        for(int i = 0; i < inventorySize-1; i++)
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

    public void Highlight(int i)
    {
        highlights[currHighlight].enabled = false;
        if (highlights[i] != null)
        {
            highlights[i].enabled = true;
        }
        currHighlight = i;
    }

    public void Clear()
    {
        highlights[currHighlight].enabled = false;
    }

    public void Prime(int i)
    {
        if (primes[i] != null)
        {
            primes[i].enabled = true;
        }
    }

    public void UnPrime(int i)
    {
        if (primes[i] != null)
        {
            primes[i].enabled = false;
        }
    }
    public void Display()
    {
        InvDisp.SetActive(true);
        open = true;
    }
    public void Hide()
    {
        InvDisp.SetActive(false);
        open = false;
    }
    public void Switch()
    {
        InvDisp.SetActive(!InvDisp.activeSelf);
        open = !open;
    }
}
