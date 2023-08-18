using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="mobile", fileName ="newMobile")]
public class Mobile_prefab_scriptable_object : ScriptableObject
{
    [Header("documents")]
    public _PDF_Scriptable_object[] pDF_Scriptable_Objects;

    [Header("videos")]
    public Video_scriptable_object[] video_Scriptable_Objects;

    [Header("images")]
    public Image_scriptableObject[] image_Scriptable_Objects;

    [Header("bins")]
    public Logs_scriptale_object[] logs_Scriptales;

    [Header("chat")]
    public Chat_scriptable_object[] chat_Scriptable_Objects;

    [Header("IP_address")]
    public string IP_address;

    [Header("proxy and firewall check")]
    public bool haveProxy = false;
    public int proxyLevel;
    public bool haveFirewall = false;
    public int FirewallType;
    public string[] Fire1wall_codes;
    public string Fire1wall_codes_solution;
    public string Fire2wall_problem;
    public string Fire2wall_problem_solution;

    [Header("Wifi")]
    public Ports[] ports;
    public int No_of_ports_needed_to_unlock;
    public int No_of_ports_unlocked;
    public int No_of_ports_total;
}
