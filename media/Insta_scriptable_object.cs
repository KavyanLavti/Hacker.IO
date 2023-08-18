using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Insta_profile",fileName ="Insta_profile")]
public class Insta_scriptable_object : ScriptableObject
{
    public Sprite[] Photos;
    public string[] descriptions;
    public string Name_of_person;
    public string[] alternate_names;
}
