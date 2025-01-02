using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : UIButton
{
    [SerializeField] private MenuButtonController menuButtonController;
    [SerializeField] private MenuButtonController.MainMenuButton mainMenuButton;

    private bool isInteractable = true;

    private void Update()
    {
        if (menuButtonController.index == (int)mainMenuButton)
        {
            animator.SetBool("selected", true);
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }

    public bool interactable
    {
        get => isInteractable;
        set => SetInteractable(value);
    }


    public void SetInteractable(bool value)
    {
        isInteractable = value;

        // Change button appearance based on interactable state
        animator.SetBool("isInteractable", value);
        
        // Optionally disable the button logic
        if (!value)
        {
            animator.SetBool("selected", false);
        }
    }

    public override void MousePointerEnter()
    {
        if (!isInteractable) return; // Ignore if not interactable
        menuButtonController.index = (int)mainMenuButton;
        base.MousePointerEnter();
    }

    public override void MousePointerExit()
    {
        if (!isInteractable) return; // Ignore if not interactable
        base.MousePointerExit();
    }

    public override void MousePointerClick()
    {
        if (!isInteractable) return; // Ignore if not interactable
        base.MousePointerClick();
        menuButtonController.Pressed();
    }
}
