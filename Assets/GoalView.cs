using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoalView : DoubleClickHandler
{
    bool isInputFormShown = false;
    Goal Goal;

    GameObject Label;
    GameObject Input;

	// Use this for initialization
	void Start () {
        Label = transform.Find("GoalLabel").gameObject;
        Input = transform.Find("Edit").gameObject;

        Redraw();
	}

    void SetData(Goal goal)
    {
        Goal = goal;

        Redraw();
    }

    void Redraw()
    {
        if (Goal != null)
            RedrawName();
    }

    public void OnEditName(string obj)
    {
        Debug.Log("OnEditName");
    }

    void RenderInput()
    {
        Input.GetComponent<Renderer>().enabled = true;
    }

    void HideInput()
    {
        Input.GetComponent<Renderer>().enabled = false;
    }

    void RenderLabel()
    {
        Label.GetComponent<Renderer>().enabled = true;
        Label.GetComponent<Text>().text = Goal.Name;
    }

    void HideLabel()
    {
        Label.GetComponent<Renderer>().enabled = false;
    }


    private void RedrawName()
    {
        if (isInputFormShown)
        {
            RenderInput();
            HideLabel();
        } else
        {
            RenderLabel();
            HideInput();
        }
    }

    public override void OnPointerDown(PointerEventData data)
    {
        base.OnPointerDown(data);

        if (isDoubleClicked)
        {
            Debug.Log("Is Double Clicked GoalView");
            isInputFormShown = true;
            //Redraw();
        }
    }
}
