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
    public InputField inputField;

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

    void Update()
    {
        if (isSelected)
            CheckKeys();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        base.OnPointerDown(data);

        if (isDoubleClicked)
        {
            isInputFormShown = true;
            Redraw();
        }
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        isSelected = true;
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

    void CheckKeys()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Goal.ToggleRequired();

            UpdateRequiredIcon();

            UpdateTitleFontStyle();
        }
    }

    public void SetData(Goal goal)
    {
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
        Goal.Name = name;
        isInputFormShown = false;

        Redraw();
    }

    void RenderInput()
    {
        inputField.text = Goal.Name;
        inputField.Select();
        inputField.ActivateInputField();

        inputField.gameObject.SetActive(true);
    }

    void HideInput()
    {
        inputField.gameObject.SetActive(false);
    }

    void UpdateTitleFontStyle()
    {
        Label.fontStyle = Goal.Required ? FontStyle.Bold : FontStyle.Normal;
    }

    void RedrawName()
    {
        UpdateTitleFontStyle();

        Label.text = Goal.Name;

        if (isInputFormShown)
        {
            RenderInput();
            Label.enabled = false;
        }
        else
        {
            HideInput();
            Label.enabled = true;
        }
    }

    void UpdateRequiredIcon()
    {
        float scale = 1.5f;

        RequiredLabel.color = Goal.Required ? Active : Inactive;
        RequiredLabel.fontStyle = Goal.Required ? FontStyle.Bold : FontStyle.Normal;
        RequiredLabel.fontSize = Goal.Required ? (int)(RequiredLabel.fontSize * scale) : (int)(RequiredLabel.fontSize / scale);
    }
}
