using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logs_controller : MonoBehaviour
{
    [Header("intantiate_Logs")]
    //public Logs_scriptale_object[] logs_Scriptable_Object;
    public TextMeshProUGUI Log_name;
    public TextMeshProUGUI Log_Body_on_open;
    public Button log_button_prefab;
    public Transform Parent_panel_transform;
    public GameObject Parent_panel;
    public GameObject log_ViewPanel;
    Button_script_logs button_Script_Logs;
    int i;

    private void Start()
    {
        log_ViewPanel.SetActive(false);
        //button_Script_Logs = new Button_script_logs[logs_Scriptable_Object.Length];
        i = 0;
    }

    public void AddLog(Logs_scriptale_object logs_Scriptable_Object)
    {
        Button newButton = Instantiate(log_button_prefab);
        newButton.transform.SetParent(Parent_panel_transform);
        newButton.onClick.AddListener(() => Open_log(newButton));
        Log_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
        Log_name.text = logs_Scriptable_Object.GetName();
        button_Script_Logs = newButton.GetComponent<Button_script_logs>();
        button_Script_Logs.Log_number = i;
        button_Script_Logs.LogName = logs_Scriptable_Object.GetName();
        button_Script_Logs.Log_Body_content_storage = logs_Scriptable_Object.GetText();
        i++;
    }
    public void Open_log(Button button)
    {
        Parent_panel.SetActive(false);
        log_ViewPanel.SetActive(true);
        Button_script_logs referance = button.GetComponent<Button_script_logs>();
        Log_Body_on_open.text = referance.Log_Body_content_storage;
    }
}
