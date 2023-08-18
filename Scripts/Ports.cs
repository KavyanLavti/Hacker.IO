using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="port",fileName ="port")]
public class Ports : ScriptableObject
{
    public string adress;
    public enum PortType
    {
        IPv4,
        IPv6
    }
    public PortType portType = new PortType();
    public bool isLocked = false;
}
