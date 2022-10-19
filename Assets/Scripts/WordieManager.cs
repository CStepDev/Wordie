using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordieManager : MonoBehaviour
{
    public Button startButton;
    public Button returnButton;

    public List<GameObject> menuObjects;
    public List<GameObject> gameObjects;

    private void StartGame()
    {
        foreach(GameObject g in menuObjects)
        {
            g.SetActive(false);
        }

        foreach(GameObject g in gameObjects)
        {
            g.SetActive(true);
        }
    }

    private void StartMenu()
    {
        foreach(GameObject g in menuObjects)
        {
            g.SetActive(true);
        }

        foreach(GameObject g in gameObjects)
        {
            g.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        startButton.name = "Start";
        returnButton.onClick.AddListener(StartMenu);
    }
}
