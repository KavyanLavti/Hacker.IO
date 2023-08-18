using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Image_Control : MonoBehaviour
{
    [Header("Image_Storage")]
    public Button Image_intantiate_prefab;
    public Transform Parent_panel_transform;
    public GameObject parent_panel;
    public GameObject Image_ViewPanel;
    public TextMeshProUGUI Image_Name;
    public Image ImageTo_view;
    Image_number image_number;
    int i;

    private void Start()
    {
        i = 0;
        Image_ViewPanel.SetActive(false);
    }
    public void AddImage(Image_scriptableObject image_ScriptableObject)
    {
        Button newButton = Instantiate(Image_intantiate_prefab);
        newButton.transform.SetParent(Parent_panel_transform);
        newButton.onClick.AddListener(() => OpenImage(newButton));
        Image_Name = newButton.GetComponentInChildren<TextMeshProUGUI>();
        image_number = newButton.GetComponent<Image_number>();
        image_number.Iname = image_ScriptableObject.get_Imagename();
        Image_Name.text = image_ScriptableObject.get_Imagename();
        image_number.number = i;
        image_number.source_image = image_ScriptableObject.get_Source_sprite();
        i++;
    }
    public void OpenImage(Button button)
    {
        parent_panel.SetActive(false);
        Image_ViewPanel.SetActive(true);
        Image_number To_Reference_image = button.GetComponent<Image_number>();
        ImageTo_view.sprite = To_Reference_image.source_image;
    }
}
