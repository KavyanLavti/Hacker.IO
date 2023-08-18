using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [Header("storage_panel")]
    public GameObject Storage_firstPage_panel;

    [Header("Second_pages")]
    public GameObject DocumentPanel;
    public GameObject ImagePanel;
    public GameObject LogsPanel;
    public GameObject VideosPanel;

    [Header("BackButton/ScriptReferences")]
    Document_controls document_Controls;
    Image_Control image_Control;
    Logs_controller log_controller;
    Video_controller video_controller;
    BG_apps_open bG_Apps_Open;

    [Header("canvas_forBackButton")]
    public GameObject BkGNDcanvas;


    private void Start()
    {
        DocumentPanel.SetActive(false);
        VideosPanel.SetActive(false);
        ImagePanel.SetActive(false);
        LogsPanel.SetActive(false);
        Storage_firstPage_panel.SetActive(true);
        document_Controls = DocumentPanel.GetComponent<Document_controls>();
        image_Control = ImagePanel.GetComponent<Image_Control>();
        log_controller = LogsPanel.GetComponent<Logs_controller>();
        video_controller = VideosPanel.GetComponent<Video_controller>();
        bG_Apps_Open = BkGNDcanvas.GetComponent<BG_apps_open>();
    }
    public void OpenDocument_panel()
    {
        DocumentPanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
    }
    public void OpenImage_panel()
    {
        ImagePanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
    }
    public void OpenVideos_panel()
    {
        VideosPanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
    }
    public void OpenLogs_panel()
    {
        LogsPanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
    }
    public void BackButton_storage()
    {
        if(DocumentPanel.activeInHierarchy)
        {
            if(document_Controls.Document_ViewPanel.activeInHierarchy)
            {
                document_Controls.Document_ViewPanel.SetActive(false);
                document_Controls.Parent_panel.SetActive(true);
            }
            else
            {
                DocumentPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (ImagePanel.activeInHierarchy)
        {
            if (image_Control.Image_ViewPanel.activeInHierarchy)
            {
                image_Control.Image_ViewPanel.SetActive(false);
                image_Control.parent_panel.SetActive(true);
            }
            else
            {
                ImagePanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (VideosPanel.activeInHierarchy)
        {
            if (video_controller.Video_Player_panel.activeInHierarchy)
            {
                video_controller.Video_Player_panel.SetActive(false);
                video_controller.Parent_panel.SetActive(true);
            }
            else
            {
                VideosPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (LogsPanel.activeInHierarchy)
        {
            if (log_controller.log_ViewPanel.activeInHierarchy)
            {
                log_controller.log_ViewPanel.SetActive(false);
                log_controller.Parent_panel.SetActive(true);
            }
            else
            {
                LogsPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else
        {
            bG_Apps_Open.ClosePanels_showBackG();
        }
    }
    
}
