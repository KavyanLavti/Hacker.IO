using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mailing : MonoBehaviour
{
    //public Singular_mail[] singular_Mail;
    public Button Mail_button_prefab;
    public Transform Parent_panel_transform;
    public GameObject Parent_panel;
    int i;
    public TextMeshProUGUI mail_front_information;
    public Image mail_DP;
    //Button[] Mails;
    //RectTransform Parent_panel_rect;
    to_store_data_about_mail_view To_Store_Data_About_Mail_View;


    [Header("mail_view")]
    public GameObject Mail_view_panel;
    public TextMeshProUGUI mail_body;
    public TextMeshProUGUI mail_Subject;

    [Header("BackButton/BCKGND")]
    public GameObject GameCanvas;
    public BG_apps_open bG_Apps_Open;

    [Header("device_spawn_button_spawn")]
    [SerializeField] Button SpawnButtonPrefab;
    [SerializeField] GameObject ParentPanelSpaWnButton;
    Event_handler_for_game event_Handler_For_game;

    private void Start()
    {
        i= 0;
        Mail_view_panel.SetActive(false);
        bG_Apps_Open = GameCanvas.GetComponent<BG_apps_open>();
        event_Handler_For_game = GameCanvas.GetComponent<Event_handler_for_game>();
        //Mails = new Button[singular_Mail.Length];
    }

    public void AddMail(Singular_mail singular_Mail)
    {
        Button newButton = Instantiate(Mail_button_prefab);
        newButton.transform.SetParent(Parent_panel_transform);
        //Parent_panel_rect = newButton.GetComponent<RectTransform>();
        newButton.onClick.AddListener(() => OpenMail(newButton) );
        mail_front_information = newButton.GetComponentInChildren<TextMeshProUGUI>();
        mail_DP = newButton.GetComponentInChildren<Image>();
        To_Store_Data_About_Mail_View = newButton.GetComponent<to_store_data_about_mail_view>();
        //To_Store_Data_About_Mail_View.Button_no = i;
        //Parent_panel_rect.SetSiblingIndex(i);
        To_Store_Data_About_Mail_View.Mail_body = singular_Mail.getMailBody();
        To_Store_Data_About_Mail_View.Mail_Subject = singular_Mail.getMailSubject();
        for (int j = 0; j < singular_Mail.DeviceInMail.Length; j++)
        {
            To_Store_Data_About_Mail_View.devicePresentArray[j] = singular_Mail.DeviceInMail[j];
            To_Store_Data_About_Mail_View.DevicePresent = true;
        }
        mail_front_information.fontStyle = FontStyles.Bold;
        mail_front_information.text = singular_Mail.getMailSender();
        mail_front_information.fontStyle ^= FontStyles.Bold;//^operator inverts - if it was set as bold it will invert it 
        mail_front_information.text += "\n"+singular_Mail.getMailSubject();
        mail_DP.sprite = singular_Mail.GetEmail_DP();
        i++;
    }
    public void OpenMail(Button button) 
    {
        to_store_data_about_mail_view OnceMore = button.GetComponent<to_store_data_about_mail_view>();
        //int j = OnceMore.Button_no;
        Parent_panel.gameObject.SetActive(false);   
        Mail_view_panel.SetActive(true);
        mail_body.text = OnceMore.Mail_body;
        mail_Subject.text = OnceMore.Mail_Subject;
    }
    public void BackButtonMailing()
    {
        if(Mail_view_panel.activeInHierarchy)
        {
            Mail_view_panel.SetActive(false);
            Parent_panel.SetActive(true);
        }
        else
        {
            bG_Apps_Open.ClosePanels_showBackG();
        }
    }
    public void AddDeviceShortCut() 
    {
        event_Handler_For_game.spawnButton();
    }
    
}


