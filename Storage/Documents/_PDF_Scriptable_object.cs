using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Documents", fileName ="_PDF")]
public class _PDF_Scriptable_object : ScriptableObject
{
    public string PDF_Name;
    public string PDF_Title;
    [TextArea(50,6)]
    public string PDF_Text;
    public bool Pass_protected = false;
    public string PassWord;

    public string GetText()
    {
        return PDF_Text;
    }
    public string GetName()
    {
        return PDF_Name;
    }
    public string GetTitle()
    {
        return PDF_Title;
    }
}
