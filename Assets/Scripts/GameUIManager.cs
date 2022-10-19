using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public List<WordController> wordsUI; // Word UI Containers
    public WordController winningWordUI; // Displays winning word
    public GameObject menuButton; // Clickable to return to the main menu

    // Sets the letter of a specific tile
    public void SetSpecificLetter(int row, int column, char letter)
    {
        wordsUI[row].SetLetter(column, letter.ToString().ToUpper());
    }

    // Sets the colour of a specific tile
    public void SetSpecificColour(int row, int column, Color newColour)
    {
        wordsUI[row].SetLetterBackground(column, newColour);
    }

    // Sets winningWordUI to the current game's word
    public void SetWinningWord(string word)
    {
        for (int i = 0; i < 5; i++)
        {
            winningWordUI.SetLetter(i, word[i].ToString().ToUpper());
        }
    }

    // Clears all letters and colours from the current state of the game UI
    public void ResetWordUI()
    {
        foreach (WordController w in wordsUI)
        {
            w.ClearLetters();
        }

        winningWordUI.ClearLetters();
    }

    // Done to avoid any extra state based logic.
    private void OnEnable()
    {
        //ResetWordUI();
        menuButton.SetActive(false);
    }
}
