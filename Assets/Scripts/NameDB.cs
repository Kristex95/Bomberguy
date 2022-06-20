using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NameDB : ScriptableObject
{
    public string[] name;

    public int NameCount
    {
        get
        {
            return name.Length;
        }
    }

    public string GetName(int index)
    {
        return name[index];
    }
}
