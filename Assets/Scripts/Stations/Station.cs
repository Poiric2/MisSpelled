using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Station : MonoBehaviour {

    public Vector3 anchor;
    public Vector3 rotVals;
    public Quaternion anchorRot;
    public Quaternion anchorCharRot;
    public AudioClip StationEffect;
    public AudioSource source;
    public Animator animator;
    public GameObject bar;
    public GameObject progbar;
    public GameObject inventoryhitbox;
    public bool working = false;
    public bool full = true;
    protected bool dragPrimed;
    protected bool dragging = true;
    protected bool operated = false;

    public int workTime = 10;

    protected Ingredient ingredient;
    protected Inventory inventory;

    public string st_name;
    public string description;

    public GameObject StationUI;
    public Text title;
    public Text dsc;
    public Image[] progress;
    public Image[] station_items;
    public Item[] items;
    public Text[] counts;
    public Text[] item_names;
    public Image[] primes;
    public Item selected;
    public Image dragPrime;
    public Image dragImage;
    public Image working_image;
    public Item working_item;
    public Text item_text;
    public GameObject dragUI;

    public bool[] station_progress;

    // Use this for initialization
    protected virtual void Start () {
        anchorRot = Quaternion.Euler(rotVals.x,0f,0f);
        anchorCharRot = Quaternion.Euler(0f, rotVals.y, 0f);
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        for (int i = 0; i < 4; i++)
        {
            if (Input.mousePosition.x > station_items[i].transform.position.x - 32 &&
               Input.mousePosition.x < station_items[i].transform.position.x + 32 &&
               Input.mousePosition.y > station_items[i].transform.position.y - 32 &&
               Input.mousePosition.y < station_items[i].transform.position.y + 32)
            {
                Prime(i);
                if (Input.GetMouseButtonDown(0) && items[i] != null)
                {
                    Drag(i);
                    dragging = true;
                }
            }
            else
            {
                UnPrime(i);
            }
        }

        if (Input.GetMouseButtonUp(0) && dragging && operated)
        {
            if (dragPrimed)
            {
                if (dragUI.transform.position.x > inventoryhitbox.transform.position.x -128 &&
               dragUI.transform.position.x < inventoryhitbox.transform.position.x + 128 &&
               dragUI.transform.position.y > inventoryhitbox.transform.position.y - 128 &&
               dragUI.transform.position.y < inventoryhitbox.transform.position.y + 161)
                {
                    inventory.Add(selected);
                    Remove(ref selected);
                }
            }
            UnDrag();
            dragging = false;
        }

        if (dragging && operated)
        {
            dragUI.transform.position = Input.mousePosition;
            if (dragUI.transform.position.x > inventoryhitbox.transform.position.x - 128 &&
               dragUI.transform.position.x < inventoryhitbox.transform.position.x + 128 &&
               dragUI.transform.position.y > inventoryhitbox.transform.position.y - 128 &&
               dragUI.transform.position.y < inventoryhitbox.transform.position.y + 161)
            {
                PrimeDrag();
            }
            else
            {
                UnPrimeDrag();
            }
        }

        if(progress != null && progress.Length == 10)
        {
            for (int i = 0; i < 10; i++)
            {
                if (progress[i] != null)
                {
                    progress[i].enabled = station_progress[i];
                }
            }
        }
    }

    public virtual void StartMode(Inventory inv){
        Cursor.lockState = CursorLockMode.None;
        inventory = inv;
        working = true;
        title.text = st_name;
        dsc.text = description;
        InitInventory();
        StationUI.SetActive(true);
        inventory.Display();
        bar.SetActive(true);
        progbar.SetActive(true);
        progress = progbar.GetComponentsInChildren<Image>();
        ingredient = null;
        operated = true;
    }

    public IEnumerator Wait()
    {
        for (int i = 0; i < workTime; i++)
        {
            station_progress[i] = true;
            yield return new WaitForSeconds(1f);
        }
        Ingredient tmp = (Ingredient)working_item;
        Job(ref tmp);
        PlaceInInventory(ref tmp);
        for(int i = 0; i < workTime; i++)
        {
            station_progress[i] = false;
        }
    }

    public virtual void Work(ref Ingredient ingredient)
    {
        source.Play();
        if (animator != null)
            animator.SetTrigger("Job");
        StartCoroutine(Wait());
        working_item = ingredient;
        working_image.sprite = working_item.sprite;
        working_image.enabled = true;
        item_text.text = working_item.name;
    }

    public virtual void Job(ref Ingredient ingredient)
    {
        ingredient.count = ingredient.count + 1;
        inventory.UpdateCounts();
    }

    public virtual void EndMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        working = false;
        StationUI.SetActive(false);
        inventory.Clear();
        inventory.Hide();
        bar.SetActive(false);
        progbar.SetActive(false);
        progress = null;
        working_image.sprite = null;
        item_text.text = "";
        operated = false;
    }

    public void InitInventory()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                station_items[i].sprite = items[i].sprite;
                station_items[i].enabled = true;
                item_names[i].text = items[i].name;
                counts[i].text = items[i].count.ToString();
            }
            else
            {
                station_items[i].sprite = null;
                station_items[i].enabled = false;
                item_names[i].text = "";
                counts[i].text = "";
            }
        }
        if(working_item != null)
        {
            working_image.sprite = working_item.sprite;
            working_image.enabled = true;
            item_text.text = working_item.name;
        }
        else
        {
            working_image.enabled = false;
            item_text.text = "";
        }
    }

    public void PlaceInInventory(ref Ingredient x)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i] == null)
            {
                items[i] = x;
                working_item = null;
                if (operated)
                    InitInventory();
                return;
            }
        }
        full = true;
        return;
    }

    public void PlaceInInventory(ref Potion x)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i] == null)
            {
                items[i] = x;
                working_item = null;
                if (operated)
                    InitInventory();
                return;
            }
        }
        full = true;
        return;
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
        dragImage.sprite = station_items[i].sprite;
        selected = items[i];
        dragUI.SetActive(true);
    }

    public void UnDrag()
    {
        dragUI.SetActive(false);
        dragImage.sprite = null;
        selected = null;
    }

    protected void Explode() {
		print ("Explode!");
	}

    public void Remove(ref Item x)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i] == x)
            {
                items[i] = null;
                station_items[i].sprite = null;
                station_items[i].enabled = false;
                counts[i].text = "";
                item_names[i].text = null;
                UpdateInventory();
                return;
            }
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < 4 - 1; i++)
        {
            if (items[i] == null && items[i + 1] != null)
            {
                items[i] = items[i + 1];
                station_items[i].sprite = items[i].sprite;
                station_items[i].enabled = true;
                counts[i].text = items[i].count.ToString();
                item_names[i].text = items[i].name;
                items[i + 1] = null;
                station_items[i + 1].enabled = false;
                item_names[i + 1].text = "";
                counts[i + 1].text = "";
            }
        }
    }
}
