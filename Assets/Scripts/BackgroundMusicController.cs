using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioSource backgroundMusic; // Controls the background music

    IEnumerator FadeInBackgroundMusic()
    {
        while (backgroundMusic.volume < 0.1f)
        {
            backgroundMusic.volume += (0.0125f * Time.deltaTime);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = this.GetComponent<AudioSource>();
        StartCoroutine(FadeInBackgroundMusic());
    }
}
