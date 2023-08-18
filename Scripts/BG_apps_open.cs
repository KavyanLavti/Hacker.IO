using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_apps_open : MonoBehaviour
{
    [Header("backGRND")]
    public GameObject terminal_Panel;
    public GameObject mail_panel;
    public GameObject notes_panel;
    public GameObject storage_panel;
    public GameObject cloud_storage_panel;
    public GameObject Messanger_panel;
    public GameObject buttons;

    [Header("scripts")]
    Terminal terminal;

    void Start()
    {
        storage_panel.SetActive(false);
        terminal_Panel.SetActive(false);
        mail_panel.SetActive(false);    
        notes_panel.SetActive(false);
        cloud_storage_panel.SetActive(false);
        Messanger_panel.SetActive(false);
        terminal = terminal_Panel.GetComponent<Terminal>();
    }
    public void openTerminal()
    {
        terminal_Panel.SetActive(true);
        buttons.SetActive(false);
        StartCoroutine(terminal.initialise(terminal.i));
        //terminal.i++;
    }
    public void openMail()
    {
        mail_panel.SetActive(true);
        buttons.SetActive(false);
    }
    public void openNotes()
    {
        notes_panel.SetActive(true);
        //for (int i = 0; i < buttons.Length; i++)
       // {
       //     buttons[i].SetActive(false);
       // }
    }
    public void openStorage()
    {
        storage_panel.SetActive(true);
        buttons.SetActive(false);
    }
    public void openCloudStorage()
    {
        cloud_storage_panel.SetActive(true);
        buttons.SetActive(false);
    }
    public void OpenMessanger()
    {
        Messanger_panel.SetActive(true );
        buttons.SetActive (false);
    }
    public void ClosePanels_showBackG()
    {
        if (mail_panel.activeInHierarchy || storage_panel.activeInHierarchy || cloud_storage_panel.activeInHierarchy || Messanger_panel.activeInHierarchy)
        {
            //terminal_Panel.SetActive(false);
            mail_panel.SetActive(false);
            cloud_storage_panel.SetActive(false);
            storage_panel.SetActive(false);
            Messanger_panel.SetActive(false);
            buttons.SetActive(true);
        }
    }
    public void terminalclose()
    {
        if(terminal_Panel.activeInHierarchy)
        {
            terminal_Panel.SetActive(false);
            buttons.SetActive(true) ;
        }
    }
}
