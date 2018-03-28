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

    protected Ingredient ingredient;
    protected Inventory inventory;

    protected bool working = false;

    public string st_name;
    public string description;

    public GameObject StationUI;
    public Text title;
    public Text dsc;

    // Use this for initialization
    protected virtual void Start () {
        anchorRot = Quaternion.Euler(rotVals.x,0f,0f);
        anchorCharRot = Quaternion.Euler(0f, rotVals.y, 0f);
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
	}

    public virtual void StartMode(Inventory inv){
        Cursor.lockState = CursorLockMode.None;
        inventory = inv;
        working = true;
        title.text = st_name;
        dsc.text = description;
        StationUI.SetActive(true);
        inventory.Display();
        ingredient = null;
    }

    protected virtual void Work()
    { 
    }

    public virtual void Job(ref Ingredient ingredient)
    {
        source.Play();
        if(animator != null)
            animator.SetTrigger("Job");
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
    }

	protected void Explode() {
		print ("Explode!");
	}
}
