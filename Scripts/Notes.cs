using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notes : MonoBehaviour
{
    [Header("Instantiate")]
    public Button Notes_prefab;
    public GameObject parent_panel;
    public Transform parent_panel_transform;
    public GameObject notes_view_panel;

    [Header("input_handeling")]
    public TMP_InputField NotesInput;
    public TMP_InputField NotesTitle;
    Notes_button notes_Button;
    TextMeshProUGUI NoteName;

    [Header("keyBoard")]
    TouchScreenKeyboard Keyboard = new TouchScreenKeyboard("", TouchScreenKeyboardType.Default, true, false, true, true, "", 0);

    [Header("back_notes")]
    public GameObject Notes_panel;

    private void Start()
    {
        Keyboard.active = false;
        notes_view_panel.SetActive(false);
    }
    public void AddNote()
    {
        Button newButton = Instantiate(Notes_prefab);
        newButton.transform.SetParent(parent_panel_transform);
        newButton.onClick.AddListener(() => OpenNote(newButton));
    }
    public void OpenNote(Button button)
    {
        parent_panel.SetActive(false);
        notes_view_panel.SetActive(true);
        notes_Button = button.GetComponent<Notes_button>();
        NoteName = button.GetComponentInChildren<TextMeshProUGUI>();
        {
            if (notes_Button.Notes_button_view_storage != null)
            {
                NotesInput.text = notes_Button.Notes_button_view_storage;
                //NoteName.text = notes_Button.NoteName;
            }
            //else { NotesInput.text = "write anything...."; }
        }
        {
            if (notes_Button.Notes_button_title != null)
            {
                NotesTitle.text = notes_Button.Notes_button_title;
            }
            //else { NotesTitle.text = "Title"; }
            //setting value of these two else statements in Notes button itself, default value of any string.
        }
    }
    public void InputAdded()
    {
        if (notes_Button != null)
        {
            notes_Button.Notes_button_title = NotesTitle.text;
            notes_Button.NoteName = NotesTitle.text;
            notes_Button.Notes_button_view_storage = NotesInput.text;
        }
    }
    public void OpenKeyboard()
    {
        Keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true);

    }
    public void closeKeyboard()
    {
        Keyboard.active = false;
        Keyboard = null;
    }
    public void BackButton_notes()
    {
        if(notes_view_panel.activeInHierarchy)
        {
            parent_panel.SetActive(true);
            notes_view_panel.SetActive(false);
            NoteName.text = notes_Button.NoteName;
        }
        else
        {
            Notes_panel.SetActive(false);
        }
        Debug.Log("Back_button_pressed");
    }
    public void OnDrag()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
    }


}
