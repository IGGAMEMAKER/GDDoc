using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// https://forum.unity.com/threads/detect-double-click-on-something-what-is-the-best-way.476759/

public class DoubleClickHandler : MonoBehaviour, IPointerDownHandler
{
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    [HideInInspector]
    public bool isDoubleClicked;

    public virtual void OnPointerDown(PointerEventData data)
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;

            isDoubleClicked = true;
            //Debug.Log("Double CLick: " + this.GetComponent<RectTransform>().name);
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
            isDoubleClicked = false;
        }
    }
}
