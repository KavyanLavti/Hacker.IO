using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class Cloud_storage_controller : MonoBehaviour
{
    public bool IsConnected = false;
    
    [Header("storage_panel")]
    public GameObject Storage_firstPage_panel;

    [Header("Second_pages")]
    public GameObject DocumentPanel;
    public GameObject ImagePanel;
    public GameObject BinPanel;
    public GameObject VideosPanel;

    [Header("BackButton/ScriptReferences")]
    BG_apps_open bG_Apps_Open;
    public GameObject BkGNDcanvas;
    public Mobile_prefab_scriptable_object Mobile_Prefab_;

    [Header("storage_panels_3rd_pages")]
    public GameObject Document_StoragePanel;
    public GameObject Image_StoragePanel;
    public GameObject Bin_StoragePanel;
    public GameObject Videos_StoragePanel;

    [Header("TransForm")]
    public Transform Document_StorageTransform;
    public Transform Image_StorageTransform;
    public Transform Bin_StorageTransform;
    public Transform Videos_StorageTransform;

    [Header("view_panels_3rd_pages")]
    public GameObject Document_viewPanel;
    public GameObject Image_viewPanel;
    public GameObject Bin_viewPanel;
    public GameObject Videos_viewPanel;

    [Header("instantiate")]
    public Button Document_prefab;
    public Button Image_prefab;
    public Button Bin_prefab;
    public Button Videos_prefab;

    [Header("document_instantiate")]
    public TextMeshProUGUI Document_name;
    public TextMeshProUGUI Document_Body_on_open;
    DocumentNumber[] documentNumbers;

    [Header("Image_instantiate")]
    public TextMeshProUGUI Image_Name;
    public Image ImageTo_view;
    Image_number[] image_number;

    [Header("Video_instantiate")]
    public TextMeshProUGUI Video_name;
    public VideoPlayer videoPlayer;
    Video_storage_per_button[] video_Storage_Per_Buttons;

    [Header("Bin_instantiate")]
    public TextMeshProUGUI Log_name;
    public TextMeshProUGUI Log_Body_on_open;
    Button_script_logs[] button_Script_Logs;


    private void Start()
    {
        DocumentPanel.SetActive(false);
        VideosPanel.SetActive(false);
        ImagePanel.SetActive(false);
        BinPanel.SetActive(false);
        bG_Apps_Open = BkGNDcanvas.GetComponent<BG_apps_open>();
    }
    private void OnEnable()
    {
        if (IsConnected)
        { 
            Storage_firstPage_panel.SetActive(true);
            Document_viewPanel.SetActive(false); 
            Image_viewPanel.SetActive(false);
            Videos_viewPanel.SetActive(false);
            Bin_viewPanel.SetActive(false);
        }
        else
        {
            Storage_firstPage_panel.SetActive(false);
        }
    }
    public void Initialisation_of_arrays()
    {
        button_Script_Logs = new Button_script_logs[Mobile_Prefab_.logs_Scriptales.Length];
        video_Storage_Per_Buttons = new Video_storage_per_button[Mobile_Prefab_.video_Scriptable_Objects.Length];
        image_number = new Image_number[Mobile_Prefab_.image_Scriptable_Objects.Length];
        documentNumbers = new DocumentNumber[Mobile_Prefab_.pDF_Scriptable_Objects.Length];
    }
    public void OpenDocument_panel()
    {
        DocumentPanel.SetActive(true);
        Document_viewPanel.SetActive(false);
        Storage_firstPage_panel.SetActive(false);
        add_ALL_Documents_in_connected_device();
    }
    public void OpenImage_panel()
    {
        ImagePanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
        add_ALL_image_in_connected_device();
    }
    public void OpenVideos_panel()
    {
        VideosPanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
        add_ALL_video_in_connected_device();
    }
    public void OpenLogs_panel()
    {
        BinPanel.SetActive(true);
        Storage_firstPage_panel.SetActive(false);
        add_ALL_bin_in_connected_device() ;
    }

    public void add_ALL_Documents_in_connected_device()
    {
        for (int i = 0; i < Mobile_Prefab_.pDF_Scriptable_Objects.Length; i++)
        {
            Button newButton = Instantiate(Document_prefab);
            newButton.transform.SetParent(Document_StorageTransform);
            newButton.onClick.AddListener(() => OpenDocument_cloud(newButton));
            Document_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
            Document_name.text = Mobile_Prefab_.IP_address + "/:" + Mobile_Prefab_.pDF_Scriptable_Objects[i].GetName();
            documentNumbers[i] = newButton.GetComponent<DocumentNumber>();
            documentNumbers[i].Document_number = i;
            //increase Font size
            documentNumbers[i].Document_Body_content_storage = Mobile_Prefab_.pDF_Scriptable_Objects[i].GetTitle();
            //decrease font size
            documentNumbers[i].Document_Body_content_storage += "\n" + "\n" + Mobile_Prefab_.pDF_Scriptable_Objects[i].GetText();
        }
    }
    public void OpenDocument_cloud(Button button)
    {
        Document_viewPanel.SetActive(true);
        Document_StoragePanel.SetActive(false);
        DocumentNumber ToReferance = button.GetComponent<DocumentNumber>();
        Document_Body_on_open.text = ToReferance.Document_Body_content_storage;
    }

    public void add_ALL_image_in_connected_device()
    {
        for (int i = 0; i < Mobile_Prefab_.image_Scriptable_Objects.Length; i++)
        {
            Button newButton = Instantiate(Image_prefab);
            newButton.transform.SetParent(Image_StorageTransform);
            newButton.onClick.AddListener(() => OpenImage_cloud(newButton));
            Image_Name = newButton.GetComponentInChildren<TextMeshProUGUI>();
            image_number[i] = newButton.GetComponent<Image_number>();
            Image_Name.text = Mobile_Prefab_.IP_address + "/:" + Mobile_Prefab_.image_Scriptable_Objects[i].get_Imagename();
            image_number[i].number = i;
            image_number[i].source_image = Mobile_Prefab_.image_Scriptable_Objects[i].get_Source_sprite();
        }
    }
    public void OpenImage_cloud(Button button)
    {
        Image_viewPanel.SetActive(true);
        Image_StoragePanel.SetActive(false);
        Image_number To_Reference_image = button.GetComponent<Image_number>();
        ImageTo_view.sprite = To_Reference_image.source_image;
    }

    public void add_ALL_video_in_connected_device()
    {
        for (int i = 0; i < Mobile_Prefab_.video_Scriptable_Objects.Length; i++)
        {
            Button newButton = Instantiate(Videos_prefab);
            newButton.transform.SetParent(Videos_StorageTransform);
            newButton.onClick.AddListener(() => OpenVideo_cloud(newButton));
            Video_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
            Video_name.text = Mobile_Prefab_.IP_address + "/:" + Mobile_Prefab_.video_Scriptable_Objects[i].Get_Video_Name();
            video_Storage_Per_Buttons[i] = newButton.GetComponent<Video_storage_per_button>();
            video_Storage_Per_Buttons[i].Number = i;
            video_Storage_Per_Buttons[i].URL = Mobile_Prefab_.video_Scriptable_Objects[i].Get_Video_URL();
        }
    }
    public void OpenVideo_cloud(Button button)
    {
        Videos_viewPanel.SetActive(true);
        Videos_StoragePanel.SetActive(false);
        Video_storage_per_button Referance = button.GetComponent<Video_storage_per_button>();
        videoPlayer.url = Referance.URL;
    }

    public void add_ALL_bin_in_connected_device()
    {
        for (int i = 0; i < Mobile_Prefab_.logs_Scriptales.Length; i++)
        {
            Button newButton = Instantiate(Bin_prefab);
            newButton.transform.SetParent(Bin_StorageTransform);
            newButton.onClick.AddListener(() => Open_log_cloud(newButton));
            Log_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
            Log_name.text = Mobile_Prefab_.IP_address + "/:" + Mobile_Prefab_.logs_Scriptales[i].GetName();
            button_Script_Logs[i] = newButton.GetComponent<Button_script_logs>();
            button_Script_Logs[i].Log_number = i;
            button_Script_Logs[i].Log_Body_content_storage = Mobile_Prefab_.logs_Scriptales[i].GetText();
        }
    }
    public void Open_log_cloud(Button button)
    {
        Bin_StoragePanel.SetActive(false);
        Bin_viewPanel.SetActive(true);
        Button_script_logs referance = button.GetComponent<Button_script_logs>();
        Log_Body_on_open.text = referance.Log_Body_content_storage;
    }

    public void BackButton_for_cloud_storage()
    {
        if (DocumentPanel.activeInHierarchy)
        {
            if (Document_viewPanel.activeInHierarchy)
            {
                Document_viewPanel.SetActive(false);
                Document_StoragePanel.SetActive(true);
            }
            else
            {
                for(int i=0; i<Document_StorageTransform.childCount; i++)
                {
                    var child = Document_StorageTransform.GetChild(i);
                    Destroy(child.gameObject);
                }
                DocumentPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (ImagePanel.activeInHierarchy)
        {
            if (Image_viewPanel.activeInHierarchy)
            {
                Image_viewPanel.SetActive(false);
                Image_StoragePanel.SetActive(true);
            }
            else
            {
                for (int i = 0; i < Image_StorageTransform.childCount; i++)
                {
                    var child = Image_StorageTransform.GetChild(i);
                    Destroy(child.gameObject);
                }
                ImagePanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (VideosPanel.activeInHierarchy)
        {
            if (Videos_viewPanel.activeInHierarchy)
            {
                Videos_viewPanel.SetActive(false);
                Videos_StoragePanel.SetActive(true);
            }
            else
            {
                for (int i = 0; i < Videos_StorageTransform.childCount; i++)
                {
                    var child = Videos_StorageTransform.GetChild(i);
                    Destroy(child.gameObject);
                }
                VideosPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else if (BinPanel.activeInHierarchy)
        {
            if (Bin_viewPanel.activeInHierarchy)
            {
                Bin_viewPanel.SetActive(false);
                Bin_StoragePanel.SetActive(true);
            }
            else
            {
                for(int i=0; i<Bin_StorageTransform.childCount; i++)
                {
                    var child = Bin_StorageTransform.GetChild(i);
                    Destroy(child.gameObject);
                }    
                BinPanel.SetActive(false);
                Storage_firstPage_panel.SetActive(true);
            }
        }
        else
        {
            bG_Apps_Open.ClosePanels_showBackG();
        }
    }

    
}
