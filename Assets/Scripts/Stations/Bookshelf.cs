using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : Station {

    public GameObject BookView;
    public Text pg1;
    public Text pg2;
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
        if(currPage < Books[currBook].pgs.Count - 1)
        {
            currPage++;
            pg1.text = pg2.text;
            pg2.text = (string)Books[currBook].pgs[currPage];  
        }
    }

    void PrevPage()
    {
        if (currPage > 1)
        {
            currPage--;
            pg2.text = pg1.text;
            pg1.text = (string)Books[currBook].pgs[currPage-1];
        }
    }

    void NextBook()
    {
        if (currBook < Books.Length - 1)
        {
            currBook++;
            currPage = 1;
            pg1.text = (string)Books[currBook].pgs[0];
            if (Books[currBook].pgs.Count > 1)
                pg2.text = (string)Books[currBook].pgs[1];
            else
                pg2.text = "";
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
            pg1.text = (string)Books[currBook].pgs[0];
            if (Books[currBook].pgs.Count > 1)
                pg2.text = (string)Books[currBook].pgs[1];
            else
                pg2.text = "";
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
        pg1.text = (string)Books[0].pgs[0];
        if (Books[0].pgs.Count > 1)
            pg2.text = (string)Books[0].pgs[1];
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
