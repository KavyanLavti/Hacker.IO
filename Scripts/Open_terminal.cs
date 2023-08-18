using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_terminal : MonoBehaviour
{

    //Vector2 startPos;
    public float distToDetect;
    public int i;

    [Header("BCGND")]
    //public GameObject gamecanva;
    BG_apps_open bG_Apps_Open;
    // bool fingerdown;

    private void Start()
    {
        bG_Apps_Open = GetComponent<BG_apps_open>();
        i = 0;
    }
    private void Update()
    {
        if(Input.touchCount>0 && i<1)
        {
            //Debug.Log("foundTouch");
            Touch touch = Input.touches[0];
            if(touch.phase==TouchPhase.Moved)
            {
                //Debug.Log("touchMoved");
                if(touch.deltaPosition.x < distToDetect) 
                {
                    bG_Apps_Open.openTerminal();
                    i++;
                    //Debug.Log("terminalOpen");
                }
            }

        }
    }
}
