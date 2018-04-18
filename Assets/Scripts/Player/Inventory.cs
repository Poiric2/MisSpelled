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
    public Text[] texts = new Text[inventorySize];
    public Text[] counts = new Text[inventorySize];

    public GameObject dragUI;
    public Image dragImage;
    public Image dragPrime;
    public bool dragPrimed;
    public Item selected;

    int currHighlight = 0;
    public bool open = false;
    
    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 16; i++)
        {
            if (items[i] != null)
            {
                images[i].sprite = items[i].sprite;
                counts[i].text = items[i].count.ToString();
                texts[i].text = items[i].name;
                images[i].enabled = true;
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddNewItem(Item x)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (items[i] == null)
            {
                items[i] = Object.Instantiate(x);
                images[i].sprite = items[i].sprite;
                counts[i].text = items[i].count.ToString();
                texts[i].text = items[i].name;
                images[i].enabled = true;
                return;
            }
        }
    }

    public void Add(Item x){
        for (int i = 0; i < inventorySize; i++){
            if(items[i] == null){
                items[i] = x;
                images[i].sprite = x.sprite;
                counts[i].text = items[i].count.ToString();
                texts[i].text = x.name;
                images[i].enabled = true;
                return;
            }
        }
    }

    public void Remove(ref Item x)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (items[i] == x)
            {
                items[i] = null;
                images[i].sprite = null;
                images[i].enabled = false;
                counts[i].text = "";
                texts[i].text = null;
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
                images[i].sprite = items[i].sprite;
                images[i].enabled = true;
                counts[i].text = items[i].count.ToString();
                texts[i].text = items[i].name;
                items[i + 1] = null;
                images[i + 1].enabled = false;
                texts[i + 1].text = "";
                counts[i + 1].text = "";
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
    }

    public void Prime(int i)
    {
        if (primes[i] != null)
        {
            primes[i].enabled = true;
        }
    }

    public void PrimeDrag()
    {
        dragPrime.enabled = true;
        dragPrimed = true;
    }

    public void UnPrime(int i)
    {
        if (primes[i] != null)
        {
            primes[i].enabled = false;
        }
    }

    public void UnPrimeDrag()
    {
        dragPrime.enabled = false;
        dragPrimed = false;
    }

    public void Drag(int i)
    {
        dragImage.sprite = images[i].sprite;
        selected = items[i];
        dragUI.SetActive(true);
    }

    public void UnDrag()
    {
        dragUI.SetActive(false);
        dragImage.sprite = null;
        selected = null;
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

    public void UpdateCounts()
    {
        for(int j = 0; j < 16; j++)
        {
            if (items[j] != null)
                counts[j].text = items[j].count.ToString();
            else
                break;
        }
    }
}
