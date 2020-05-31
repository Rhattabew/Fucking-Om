using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextColour : MonoBehaviour
{
    public TextMeshProUGUI[] help;
    public float timer = 0.1f;
    public Color32 textColor32;

    void Update()
    {
        Clock();
    }
    
    void Clock()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            ColourChange();
            timer = 0.1f;
        }
    }

    void ColourChange()
    {
        textColor32 = new Color32(
            (byte)Random.Range(0, 255),   // Red.
            (byte)Random.Range(0, 255),   // Blue.
            (byte)Random.Range(0, 255),   // Green.
            (byte)Random.Range(0, 255)); // Alpha.      
        help[0].color = textColor32;

        textColor32 = new Color32(
            (byte)Random.Range(0, 255),   // Red.
            (byte)Random.Range(0, 255),   // Blue.
            (byte)Random.Range(0, 255),   // Green.
            (byte)Random.Range(0, 255)); // Alpha.
        help[1].color = textColor32;

        textColor32 = new Color32(
    (byte)Random.Range(0, 255),   // Red.
    (byte)Random.Range(0, 255),   // Blue.
    (byte)Random.Range(0, 255),   // Green.
    (byte)Random.Range(0, 255)); // Alpha.
        help[2].color = textColor32;

    }
}
