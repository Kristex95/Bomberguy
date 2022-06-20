using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_Skin_Select : MonoBehaviour
{
    public AnimatorDB animDB;
    private SpriteRenderer sr;

    public Animator animator;
    protected AnimatorOverrideController animatorOverrideController;

    private int selectedOption = 0;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateAnimator();
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= animDB.AnimationCount)
        {
            selectedOption = 0;
        }

        UpdateAnimator();
    }

    public void PrevOption()
    {
        selectedOption++;
        if (selectedOption < 0)
        {
            selectedOption = animDB.AnimationCount - 1;
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        RuntimeAnimatorController controller = animDB.GetAnimator(selectedOption);
        this.animator.runtimeAnimatorController = controller;
        sr.sprite = animDB.GetSprite(selectedOption);
    }

    public void UpdateAnimator(int option)
    {
        while (option >= animDB.AnimationCount)
        {
            option -= animDB.AnimationCount;
        }
        RuntimeAnimatorController controller = animDB.GetAnimator(option);
        this.animator.runtimeAnimatorController = controller;
        sr.sprite = animDB.GetSprite(option);
    }
}
