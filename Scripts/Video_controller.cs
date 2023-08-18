using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Video_controller : MonoBehaviour
{
    [Header("Viedo_storage")]
    public Button Instantiate_prefab;
    public Transform parent_panel_transform;
    public GameObject Parent_panel;
    public GameObject Video_Player_panel;
    public TextMeshProUGUI Video_name;
    //public Video_scriptable_object[] video_Scriptable_Objects;
    public VideoPlayer videoPlayer;
    Video_storage_per_button video_Storage_Per_Buttons;
    int i;
    private void Start()
    {
        Video_Player_panel.SetActive(false);
        i = 0;
        //video_Storage_Per_Buttons = new Video_storage_per_button[video_Scriptable_Objects.Length];
    }
    public void AddVideo(Video_scriptable_object video_Scriptable_Object)
    {
        Button newButton = Instantiate(Instantiate_prefab);
        newButton.transform.SetParent(parent_panel_transform);
        newButton.onClick.AddListener(() => OpenVideo(newButton));
        Video_name = newButton.GetComponentInChildren<TextMeshProUGUI>();
        Video_name.text = video_Scriptable_Object.Get_Video_Name();
        video_Storage_Per_Buttons = newButton.GetComponent<Video_storage_per_button>();
        video_Storage_Per_Buttons.Vname = video_Scriptable_Object.Get_Video_Name();
        video_Storage_Per_Buttons.Number = i;
        video_Storage_Per_Buttons.URL = video_Scriptable_Object.Get_Video_URL();
        i++;
    }
    public void OpenVideo(Button button)
    {
        Video_Player_panel.SetActive(true);
        Parent_panel.SetActive(false);
        Video_storage_per_button Referance = button.GetComponent<Video_storage_per_button>();
        videoPlayer.url = Referance.URL;
        videoPlayer.Play();
    }
}
