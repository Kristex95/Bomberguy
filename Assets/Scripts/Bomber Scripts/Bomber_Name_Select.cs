using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomber_Name_Select : MonoBehaviour
{
    public TextMeshProUGUI name;
    public NameDB nameDB;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= nameDB.NameCount)
        {
            selectedOption = 0;
        }

        UpdateName();
    }

    public void PrevOption()
    {
        selectedOption++;
        if (selectedOption < 0)
        {
            selectedOption = nameDB.NameCount - 1;
        }

        UpdateName();
    }

    private void UpdateName()
    {
        name.text = nameDB.GetName(selectedOption);
    }

    public void UpdateName(int option)
    {
        while(option >= nameDB.NameCount)
        {
            option -= nameDB.NameCount;
        }
        name.text = nameDB.GetName(option);
    }
}
