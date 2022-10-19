using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<string> words; // Imported list of words from validwords.txt
    public GameObject menuButton; // Ref to the menu button in the canvas
    public GameUIManager uiManager; // Handles UI related tasks
    public int currentAttempt; // Row
    public int charPosition; // Column
    public string currentWord; // The randomly selected word from 'words'
    public string inputtedWord; // Holds current inputted word

    // Randomly selects another word for the game to use
    private void ChangeWord()
    {
        currentWord = words[Random.Range(0, words.Count)];
    }

    // Updates the UI based on accuracy of player guesses
    private void VerifyGuessedCharacters()
    {
        int index = 0;
        foreach (char c in inputtedWord)
        {
            if ((currentWord.Contains(c)) && !(currentWord[index] == c))
            {
                uiManager.SetSpecificColour(currentAttempt, index, Color.yellow);
            }
            else if (currentWord[index] == c)
            {
                uiManager.SetSpecificColour(currentAttempt, index, Color.green);
            }
            else
            {
                uiManager.SetSpecificColour(currentAttempt, index, Color.gray);
            }

            index++;
        }
    }

    // Check formed input string
    private void CheckInputtedWord()
    {
        VerifyGuessedCharacters();

        if (inputtedWord == currentWord)
        {
            menuButton.SetActive(true);
        }
        else if (!words.Contains(inputtedWord))
        {
            menuButton.SetActive(true);
            uiManager.SetWinningWord(currentWord);
        }
    }

    // Capture typing input
    void HandlePlayingInput()
    {
        foreach (char c in Input.inputString)
        {
            if ((c == '\n') || (c == '\r'))
            {
                if (currentAttempt < uiManager.wordsUI.Count - 1)
                {
                    CheckInputtedWord();
                    currentAttempt++;
                    charPosition = 0;
                }
                else
                {
                    menuButton.SetActive(true);
                    VerifyGuessedCharacters();
                    uiManager.SetWinningWord(currentWord);
                }

                inputtedWord = "";
            }
            else if (c == '\b')
            {
                if (inputtedWord.Length > 0)
                {
                    charPosition--;
                    uiManager.SetSpecificLetter(currentAttempt, charPosition, '_');

                    inputtedWord = inputtedWord.Remove(inputtedWord.Length - 1);
                }
            }
            else
            {
                if ((inputtedWord.Length < 5) && (currentAttempt < 5))
                {
                    inputtedWord += c;
                    uiManager.SetSpecificLetter(currentAttempt, charPosition, c);

                    charPosition++;
                }
            }
        }
    }

    // Set the first row first column to a hint letter and move the "input cursor"
    void SetFirstHint()
    {
        inputtedWord += currentWord[0];
        uiManager.SetSpecificLetter(0, 0, currentWord[0]);
        uiManager.SetSpecificColour(0, 0, Color.green);
        charPosition = 1;
    }

    // Resets the basic game variables to replay the game
    void ResetGameVariables()
    {
        currentAttempt = 0; // Row
        charPosition = 0; // Column
        inputtedWord = ""; // Holds current inputted word
        ChangeWord();
    }

    private void OnEnable()
    {
        words = this.gameObject.GetComponent<TxtLoader>().WordsList();
        ResetGameVariables();
        uiManager.ResetWordUI();
        SetFirstHint();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayingInput();
    }
}
