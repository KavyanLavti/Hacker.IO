using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Logs", fileName = "_text")]
public class Logs_scriptale_object : ScriptableObject
{
    public string Log_Name;
    [TextArea(50, 6)]
    public string Log_Text;


    public string GetText()
    {
        return Log_Text;
    }
    public string GetName()
    {
        return Log_Name;
    }
}
