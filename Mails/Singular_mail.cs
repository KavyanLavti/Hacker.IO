using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "mail", fileName ="new Mail")]
public class Singular_mail : ScriptableObject
{
    [SerializeField] string MailSender;
    [SerializeField] string MailSubject;
    [SerializeField] Sprite Email_DP;
    [TextArea(20,6)]
    [SerializeField] string MailBody;

    [Header("New Computers")]
    public bool[] DeviceInMail;
    //public int NumberOfDeviceInmail;
    
    public string getMailSender()
    { return MailSender; }
    public string getMailSubject()
    { return MailSubject; }
    public Sprite GetEmail_DP()
    { return Email_DP; }
    public string getMailBody()
    { return MailBody; }
}
