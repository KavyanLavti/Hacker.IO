using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "image_data", fileName ="Images_stored")]
public class Image_scriptableObject : ScriptableObject
{
    public string ImageName;
    public Sprite Source_sprite;
    public string get_Imagename()
    {
        return ImageName;
    }
    public Sprite get_Source_sprite()
    {
        return Source_sprite;
    }
}
