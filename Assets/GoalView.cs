using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoalView : DoubleClickHandler, IPointerDownHandler, ISelectHandler, IDeselectHandler
{
    bool isInputFormShown = false;
    Goal Goal;

    public GameObject Label;
    public GameObject Input;

    Selectable Selectable;

	// Use this for initialization
	void Start () {
        Goal = new Goal();

        Selectable = GetComponent<Selectable>();
    }
    
    public void SetData(Goal goal)
    {
        Debug.LogFormat("SetData in GoalView: " + goal.Name);
        Goal = goal;

        Redraw();
    }

    void Redraw()
    {
        //if (Goal != null)
            RedrawName();
    }



    public void OnEditName(string name)
    {
        Debug.Log("OnEditName");

        Goal.Name = name;
        isInputFormShown = false;

        Redraw();
    }

    void RenderInput()
    {
        InputField inputField = Input.GetComponent<InputField>();
        Input.SetActive(true);

        inputField.text = Goal.Name;
        inputField.Select();
        inputField.ActivateInputField();
    }

    void HideInput()
    {
        Input.SetActive(false);
    }

    void RenderLabel()
    {
        Label.SetActive(true);
        Label.GetComponent<Text>().text = Goal.Name;
    }

    void HideLabel()
    {
        Label.SetActive(false);
    }

    private void RedrawName()
    {
        if (isInputFormShown)
        {
            RenderInput();
            HideLabel();
        }
        else
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
            Redraw();
        }
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.LogFormat("Component {0} is selected", Goal.Name);
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was Deselected");
    }
}
