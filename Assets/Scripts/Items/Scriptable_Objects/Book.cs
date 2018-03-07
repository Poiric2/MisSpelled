using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Book : ScriptableObject{
    public string title;
    public List<string> pgs;
}