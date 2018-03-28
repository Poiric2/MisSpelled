using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Book : ScriptableObject{
    public string title;
    public List<Sprite> page_images;
}