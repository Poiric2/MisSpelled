using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aux_rotate : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Rotate(Vector3.right, 0.5f * speed * Time.deltaTime);
        transform.Rotate(Vector3.left, 2 * speed * Time.deltaTime);
	}
}
