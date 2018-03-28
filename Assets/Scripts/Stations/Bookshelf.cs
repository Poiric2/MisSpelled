using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : Station {

    public GameObject BookView;
    public Image pg1;
    public Image pg2;
    public Text Title1;
    public Text Title2;

    int currPage;
    int currBook;

    public Book[] Books = new Book[5];

	// Use this for initialization
	protected override void Start () {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Work()
    {
        BookView.SetActive(true);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PrevPage();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            NextBook();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PrevBook();
        }
    }

    void NextPage()
    {
        if(currPage < Books[currBook].page_images.Count - 1)
        {
            currPage++;
            pg1.sprite = pg2.sprite;
            pg2.sprite = Books[currBook].page_images[currPage];  
        }
    }

    void PrevPage()
    {
        if (currPage > 1)
        {
            currPage--;
            pg2.sprite = pg1.sprite;
            pg1.sprite = Books[currBook].page_images[currPage-1];
        }
    }

    void NextBook()
    {
        if (currBook < Books.Length - 1)
        {
            currBook++;
            currPage = 1;
            pg1.sprite = Books[currBook].page_images[0];
            if (Books[currBook].page_images.Count > 1)
                pg2.sprite = Books[currBook].page_images[1];
            else
                pg2.sprite = null;
            Title1.text = (string)Books[currBook].title;
            Title2.text = (string)Books[currBook].title;
        }
    }

    void PrevBook()
    {
        if(currBook > 0)
        {
            currBook--;
            currPage = 1;
            pg1.sprite = Books[currBook].page_images[0];
            if (Books[currBook].page_images.Count > 1)
                pg2.sprite = Books[currBook].page_images[1];
            else
                pg2.sprite = null;
            Title1.text = (string)Books[currBook].title;
            Title2.text = (string)Books[currBook].title;
        }
    }

    public override void StartMode(Inventory inv)
    {
        Cursor.lockState = CursorLockMode.None;
        working = true;
        currBook = 0;
        currPage = 1;
        pg1.sprite = Books[0].page_images[0];
        if (Books[0].page_images.Count > 1)
            pg2.sprite = Books[0].page_images[1];
        Title1.text = (string)Books[0].title;
        Title2.text = (string)Books[0].title;
        BookView.SetActive(true);
    }

    public override void EndMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        working = false;
        BookView.SetActive(false);
    }
}
