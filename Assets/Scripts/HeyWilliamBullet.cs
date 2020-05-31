using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeyWilliamBullet : MonoBehaviour
{
    public TextMeshPro help;
    public float timer = 0.1f;
    public Color32 textColor32;

    void Update()
    {
        Clock();
    }
    void Clock()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
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
        help.color = textColor32;
    }
}
