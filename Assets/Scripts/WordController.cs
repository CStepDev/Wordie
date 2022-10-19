using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    [SerializeField] List<LetterController> letterList;

    public void SetLetter(int position, string newLetter)
    {
        letterList[position].SetDisplayLetter(newLetter);
    }

    public void SetLetterBackground(int position, Color color)
    {
        letterList[position].SetBackgroundColor(color);
    }

    public void ClearLetters()
    {
        foreach(var i in letterList)
        {
            i.SetDisplayLetter("_");
            i.SetBackgroundColor(Color.white);
        }
    }
}
