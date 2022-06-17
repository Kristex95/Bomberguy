using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AnimatorDB : ScriptableObject
{
    public RuntimeAnimatorController[] animator;
    public Sprite[] sprite;

    public int AnimationCount 
    {
        get
        {
            return animator.Length; 
        }
    }

    public RuntimeAnimatorController GetAnimator(int index)
    {
        return animator[index];
    }

    public Sprite GetSprite(int index)
    {
        return sprite[index];
    }
}
