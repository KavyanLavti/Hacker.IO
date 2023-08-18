using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Chat_asset",fileName ="chat_no")]
public class Chat_scriptable_object : ScriptableObject
{
    public string Chat_group_name;
    [TextArea(2,8)]
    public string[] myMessages;
    [TextArea(2,8)]
    public string[] recieved_messages;
    public int[] sequence;
}
