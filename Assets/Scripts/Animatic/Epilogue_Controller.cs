using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilogue_Controller : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (camera2.activeSelf == false && Input.GetMouseButtonDown(0))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }

        else if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }
    }
}
