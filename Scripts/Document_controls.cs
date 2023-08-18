using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Document_controls : MonoBehaviour
{
    [Header("intantiate_documents")]
    //public _PDF_Scriptable_object[] _pDF_Scriptable_Object;
    public TextMeshProUGUI Document_name;
    public TextMeshProUGUI Document_Body_on_open;
    public Button Document_button_prefab;
    public Transform Parent_panel_transform;
    public GameObject Parent_panel;
    public GameObject Document_ViewPanel; 
    DocumentNumber documentNumbers;
    int i;

    [Header("pass_protection")]
    public GameObject Pass_panel;
    InputField Pass_panel_input;
    //TextMeshProUGUI Pass_panel_text;

    [Header("Guide")]
    public GameObject guide_panel;
    public TextMeshProUGUI Guide_;

    private void Start()
    {
        Document_ViewPanel.SetActive(false);
        //documentNumbers = new DocumentNumber[_pDF_Scriptable_Object.Length];
        i= 0;
        Pass_panel_input = Pass_panel.GetComponentInChildren<InputField>();
        //Pass_panel_text = Pass_panel.GetComponentInChildren<TextMeshProUGUI>();
        Guide_ = guide_panel.GetComponent<TextMeshProUGUI>();
    }

    public void AddDocument(_PDF_Scriptable_object _PDF_Scriptable_Object)
    {
        Button newButton = Instantiate(Document_button_prefab);
        newButton.transform.SetParent(Parent_panel_transform);
        newButton.onClick.AddListener(() => Open_PDF_DOCUMENT_file(newButton));
        Document_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
        documentNumbers = newButton.GetComponent<DocumentNumber>();
        Document_name.text = _PDF_Scriptable_Object.GetName();
        documentNumbers.Dname = _PDF_Scriptable_Object.GetName();
        documentNumbers.Document_number = i;
        //increase Font size
        documentNumbers.Document_Body_content_storage = _PDF_Scriptable_Object.GetTitle();
        //decrease font size
        documentNumbers.Document_Body_content_storage += "\n" + "\n" + _PDF_Scriptable_Object.GetText();
        documentNumbers.pass_protected = _PDF_Scriptable_Object.Pass_protected;
        documentNumbers.Password = _PDF_Scriptable_Object.PassWord;
        i++;
    }
    public void Open_PDF_DOCUMENT_file(Button button)
    {
        Parent_panel.SetActive(false);
        DocumentNumber ToReferance = button.GetComponent<DocumentNumber>();
        int j = ToReferance.Document_number;
        Document_Body_on_open.text = ToReferance.Document_Body_content_storage;
        if(!ToReferance.pass_protected) Document_ViewPanel.SetActive(true);
        else
        {
            Pass_panel.SetActive(true);
            Pass_panel_input.onEndEdit.AddListener((string password) => PassWord_crack(ToReferance.Password));
        }
    }
    public void PassWord_crack(string password)
    {
        if (Pass_panel_input.text == password)
        {
            Document_ViewPanel.SetActive(true);
            Pass_panel.SetActive(false);
        }
        else
        {
            guide_panel.SetActive(true);
            Guide_.color = Color.red;
            Guide_.fontSize = 100f;
            Guide_.text = "<color=red>INCORRECT PASSWORD</color>\n";
        }
    }
}
