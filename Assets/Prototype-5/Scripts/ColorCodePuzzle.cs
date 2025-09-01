using System.Collections.Generic;
using UnityEngine;

public class ColorCodePuzzle : MonoBehaviour
{
    public string[] correctSequence = { "Blue", "Red", "Green" };
    private int currentIndex = 0;

    public GameObject doorToUnlock;

    private List<ColorButton> pressedButtons = new List<ColorButton>();

    public void PressColor(ColorButton button)
    {
        if (button.colorName == correctSequence[currentIndex])
        {
            button.TurnOnLight(); // Keep light on
            pressedButtons.Add(button); // Track pressed buttons

            currentIndex++;

            if (currentIndex >= correctSequence.Length)
            {
                Debug.Log("Color puzzle complete!");
                doorToUnlock.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Wrong color. Puzzle reset.");
            ResetPuzzle();
        }
    }

    public void ResetPuzzle()
    {
        currentIndex = 0;

        // Turn off all previously pressed lights
        foreach (ColorButton btn in pressedButtons)
        {
            btn.TurnOffLight();
        }

        pressedButtons.Clear();
    }
}
