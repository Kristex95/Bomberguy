using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerImageScript : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI gameResult;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWinnerImage(GameObject player)
    {
        img.sprite = player.GetComponent<SpriteRenderer>().sprite;
        img.color = new Color(1f, 1f, 1f, 1f);
        gameResult.text = "YOU ARE A WINNER!";
    }

    public void Draw()
    {
        img.color = new Color(1f, 1f, 1f, 0f);
        gameResult.text = "DRAW!";
    }
}
