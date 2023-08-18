using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Media_controller : MonoBehaviour
{
    public GameObject Instantiate_prefab;
    public Transform parent_panel_transform;
    public Insta_scriptable_object Media_store;

    public void InstaPageVisit()
    {
        for (int i = 0; i < Media_store.descriptions.Length; i++)
        {
            GameObject newGameObject = Instantiate(Instantiate_prefab);
            newGameObject.transform.parent = parent_panel_transform;
            Image imm = newGameObject.GetComponentInChildren<Image>();
            imm.sprite = Media_store.Photos[i];
            TextMeshProUGUI about = newGameObject.GetComponent<TextMeshProUGUI>();
            about.text = Media_store.descriptions[i];
        }
    }
    public void BackButton_media()
    {
        for(int i =0; i<transform.childCount; i++) 
        {
            Destroy(transform.GetChild(i));
        }
    }
}
