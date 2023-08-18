using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class messanger : MonoBehaviour
{
    [Header("Instantiate_storage")]
    public Button ChatButton;
    public Transform parent_transform;
    public GameObject storage_gameobject;
    public GameObject view_gameobject;
    TextMeshProUGUI Chat_name;
    Attachedtobutton attachedtobutton;

    [Header("gameCanvas")]
    public GameObject Gamecanvas;
    Event_handler_for_game event_Handler_For_Game;
    BG_apps_open bG_Apps_Open;

    [Header("Messages")]
    public GameObject My_message;
    public GameObject received_message;
    public Transform View_panel_transform;
    public GameObject view_panel_transform_gameobject;
    //VerticalLayoutGroup layout_view_chat;
    //int i;

    [Header("mobile_prefab")]
    public Mobile_prefab_scriptable_object Mobile_for_chat;

    private void Start()
    {
        view_gameobject.SetActive(false);
        event_Handler_For_Game = Gamecanvas.GetComponent<Event_handler_for_game>();
        bG_Apps_Open = Gamecanvas.GetComponent<BG_apps_open>();
        //layout_view_chat = View_panel_transform.gameObject.GetComponent<VerticalLayoutGroup>();
    }

    public void AddChat(int i)
    {
        Button newButton = Instantiate(ChatButton);
        newButton.transform.SetParent(parent_transform);
        newButton.onClick.AddListener(() => OpenChat(newButton));
        Chat_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
        attachedtobutton = newButton.GetComponent<Attachedtobutton>();
        attachedtobutton.attachedToButton_MYMessages = new string[Mobile_for_chat.chat_Scriptable_Objects[i].myMessages.Length];
        attachedtobutton.attachedToButton_recievedMessages = new string[Mobile_for_chat.chat_Scriptable_Objects[i].recieved_messages.Length];
        attachedtobutton.sequence = new int[Mobile_for_chat.chat_Scriptable_Objects[i].sequence.Length];
        Chat_name.text = Mobile_for_chat.chat_Scriptable_Objects[i].Chat_group_name;
        for (int j = 0; j < Mobile_for_chat.chat_Scriptable_Objects[i].myMessages.Length; j++)
        {
            attachedtobutton.attachedToButton_MYMessages[j] = Mobile_for_chat.chat_Scriptable_Objects[i].myMessages[j];
        }
        for (int j = 0; j < Mobile_for_chat.chat_Scriptable_Objects[i].recieved_messages.Length; j++)
        {
            attachedtobutton.attachedToButton_recievedMessages[j] = Mobile_for_chat.chat_Scriptable_Objects[i].recieved_messages[j];
        }
        for(int j=0; j< Mobile_for_chat.chat_Scriptable_Objects[i].sequence.Length; j++)
        {
            attachedtobutton.sequence[j] = Mobile_for_chat.chat_Scriptable_Objects[i].sequence[j];
        }
    }
    public void OpenChat(Button button)
    {
        view_gameobject.SetActive(true);
        storage_gameobject.SetActive(false);
        Attachedtobutton referance = button.GetComponent<Attachedtobutton>();
        int m = 0;
        int r = 0;
        for (int k = 0; k < referance.sequence.Length; k++)
        {
            if (referance.sequence[k] == 0)
            {
                GameObject newGameObject = Instantiate(My_message);
                TextMeshProUGUI New_MyMessage = newGameObject.GetComponent<TextMeshProUGUI>();
                //RectTransform rectTransform = newGameObject.GetComponent<RectTransform>();
                //rectTransform.anchoredPosition = Vector2.zero;
                //rectTransform.localScale = Vector3.one;
                New_MyMessage.transform.SetParent(View_panel_transform);
                New_MyMessage.text = referance.attachedToButton_MYMessages[m];
                m++;
            }
            else if (referance.sequence[k] == 1)
            {
                GameObject newGameObject = Instantiate(received_message); ;
                TextMeshProUGUI New_recievedMessage = newGameObject.GetComponent<TextMeshProUGUI>();
                //RectTransform rectTransform = newGameObject.GetComponent<RectTransform>();
                //rectTransform.anchoredPosition = Vector2.zero;
                //rectTransform.localScale = Vector3.one;
                New_recievedMessage.transform.SetParent(View_panel_transform);
                New_recievedMessage.text = referance.attachedToButton_recievedMessages[r];
                r++;
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(view_panel_transform_gameobject.GetComponent<RectTransform>());

    }
    public void BackButton_messanger()
    {
        if (view_gameobject.activeInHierarchy)
        {
            for(int k = 0; k< View_panel_transform.childCount; k++)
            {
                var child = View_panel_transform.GetChild(k);
                Destroy(child.gameObject);
            }
            view_gameobject.SetActive(false);
            storage_gameobject.SetActive(true);
        }
        else
        {
            bG_Apps_Open.ClosePanels_showBackG();
        }
    }

}
