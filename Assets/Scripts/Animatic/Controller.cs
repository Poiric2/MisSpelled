using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public List<GameObject> frames;
    int index = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (index > 3)
        {
            SceneManager.LoadScene("Lab_Alt");
        }

        else if (Input.GetMouseButtonDown(0))
        {
            index += 1;
            frames[index].SetActive(true);
            frames[index-1].SetActive(false);
        }

        
	}
}
