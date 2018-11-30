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

    bool isSelected;

    public Text Label;
    public GameObject InputField;

    public Text BuildLabel;
    public Text RequiredLabel;

    Selectable Selectable;

    Color Active = Color.white;
    Color Inactive = Color.black;

	// Use this for initialization
	void Start () {
        Goal = new Goal();

        Selectable = GetComponent<Selectable>();
    }
    
    public void SetData(Goal goal)
    {
        //Debug.LogFormat("SetData in GoalView: " + goal.Name);
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
        InputField inputField = InputField.GetComponent<InputField>();
        InputField.SetActive(true);

        inputField.text = Goal.Name;
        inputField.Select();
        inputField.ActivateInputField();
    }

    void HideInput()
    {
        InputField.SetActive(false);
    }

    void UpdateTitleFontStyle()
    {
        Label.fontStyle = Goal.Required ? FontStyle.Bold : FontStyle.Normal;
    }

    private void RedrawName()
    {
        Label.text = Goal.Name;
        Label.enabled = !isInputFormShown;
        UpdateTitleFontStyle();

        if (isInputFormShown)
            RenderInput();
        else
            HideInput();
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
        isSelected = true;
        Debug.LogFormat("Component {0} is selected", Goal.Name);
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        Debug.Log(this.gameObject.name + " was Deselected");
    }

    void Update()
    {
        if (isSelected)
            CheckKeys();
    }

    private void CheckKeys()
    {
        if (Input.GetKeyUp(KeyCode.R))
            ToggleIsRequired();
    }

    private void ToggleIsRequired()
    {
        Goal.ToggleRequired();

        float scale = 1.5f;

        RequiredLabel.color = Goal.Required ? Active : Inactive;
        RequiredLabel.fontStyle = Goal.Required ? FontStyle.Bold : FontStyle.Normal;
        RequiredLabel.fontSize = Goal.Required ? (int)(RequiredLabel.fontSize * scale) : (int)(RequiredLabel.fontSize / scale);

        //RequiredLabel.enabled = Goal.Required;

        UpdateTitleFontStyle();
    }
}
