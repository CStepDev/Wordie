using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentLetter;
    [SerializeField] Image backgroundImage;

    private void Awake()
    {
        currentLetter = this.GetComponent<TextMeshProUGUI>();
        backgroundImage = GetComponentInParent<Image>();
    }

    public void SetBackgroundColor(Color newColor)
    {
        backgroundImage.color = newColor;
    }

    public void SetDisplayLetter(string letter)
    {
        currentLetter.text = letter;
    }
}
