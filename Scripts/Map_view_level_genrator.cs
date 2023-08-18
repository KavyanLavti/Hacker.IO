using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_view_level_genrator : MonoBehaviour
{
    [Header("prefabs")]
    public Button mobile_prefab;
    public Button computer_prefab;
    public Button server_prefab;

    [Header("Map_view_instantiate")]
    public Transform map_view;
    Mobile_prefab_script mobile_Prefab_Script;

    [Header("clouDstorage")]
    public GameObject Cloud_storage;
    Cloud_storage_controller cloud_storage_controller;

    [Header("chat")]
    public GameObject chat_panel;
    messanger messanger_prefab;

    [Header("terminal")]
    public GameObject terminal_panel;
    Terminal terminal;

    [Header("masterscript")]
    Event_handler_for_game event_Handler_For_Game;
    public GameObject GameCanvas;

    private void Start()
    {
        cloud_storage_controller = Cloud_storage.GetComponent<Cloud_storage_controller>();
        terminal = terminal_panel.GetComponent<Terminal>();
        event_Handler_For_Game = GameCanvas.GetComponent<Event_handler_for_game>();
        messanger_prefab = chat_panel.GetComponent<messanger>();
    }
    public void Instantiate_New_device(RectTransform rectTransform, Mobile_prefab_scriptable_object mobile_Prefab_Scriptable_Object)
    {
        {
            Button newButton = Instantiate(mobile_prefab);
            newButton.transform.SetParent(map_view.transform);
            newButton.transform.localPosition = rectTransform.localPosition;
            newButton.onClick.AddListener(() => OnConnect(newButton));
            mobile_Prefab_Script = newButton.GetComponent<Mobile_prefab_script>();
            mobile_Prefab_Script.mobile_Prefab_Scriptable_Object = mobile_Prefab_Scriptable_Object;
        }
    }
    public void OnConnect(Button button)
    {
        //cloud_storage_controller.IsConnected = true;
        StartCoroutine(terminal.ConnectTodevice());
        terminal.isConnected = true;
        //start text box and type method of sequrity detected
        terminal.mobile_for_terminal = button.GetComponent<Mobile_prefab_script>().mobile_Prefab_Scriptable_Object;
        //terminal.TerminalOutput.text += "foundfound"; not going to work that way
        cloud_storage_controller.Mobile_Prefab_ = button.GetComponent<Mobile_prefab_script>().mobile_Prefab_Scriptable_Object;
        messanger_prefab.Mobile_for_chat = button.GetComponent<Mobile_prefab_script>().mobile_Prefab_Scriptable_Object;
        for(int i = 0; i < messanger_prefab.Mobile_for_chat.chat_Scriptable_Objects.Length; i++) 
        {
            messanger_prefab.AddChat(i);
        }
        cloud_storage_controller.Initialisation_of_arrays();
        button.interactable = false;
    }
}
