using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public int count = 0;

	public string form;
	public string destruction = "pure";

	public int red;
	public int orange;
	public int yellow;
	public int green;
	public int blue;
	public int purple;
}
