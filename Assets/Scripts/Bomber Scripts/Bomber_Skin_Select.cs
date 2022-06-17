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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NextOption();
        }
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
}
