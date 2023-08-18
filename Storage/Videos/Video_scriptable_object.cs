using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="video_prefab", fileName ="video")]
public class Video_scriptable_object : ScriptableObject
{
    public string URL;
    public string Video_Name;

    public string Get_Video_URL()
    {
        return URL;
    }
    public string Get_Video_Name()
    {
        return Video_Name;
    }
}
