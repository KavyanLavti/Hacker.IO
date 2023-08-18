using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_handler_for_game : MonoBehaviour
{
    bool[] Level;
    public int maxLevels;
    //public Mobile_prefab_scriptable_object[] mobile_scriptable_object;

    [Header("map")]
    public RectTransform[] toGenrate_onMap;
    public GameObject Terminal_window;
    Map_view_level_genrator map_View_Level_Genrator;
    int level_started;

    private void Start()
    {
        Level = new bool[maxLevels];
        for (int i = 0; i < Level.Length; i++)
        {
            Level[i] = false;
        }
        Level[0] = true;
        level_started = 0;
        map_View_Level_Genrator = Terminal_window.GetComponent<Map_view_level_genrator>();
    }
    public void Increase_the_level()
    {
        for(int i=0; i<Level.Length; i++)
        {
            if(!Level[i])
            {
                Level[i] = true;
                level_started = i;
                break;
                //when a level[i] becomes true it means the level has started not finished
            }
            else if (Level[maxLevels-1])
            {
                //do final video play
            }
        }
    }
    public void spawnButton()
    {
        if(level_started == 0)
        {
           // map_View_Level_Genrator.Instantiate_New_device(toGenrate_onMap[0], 0);
        }
        else if(level_started == 1)
        {
           // map_View_Level_Genrator.Instantiate_New_device(toGenrate_onMap[1], 1);
        } 
    }
    
}
