using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class videoScript : MonoBehaviour
{
    public levelLoader levelLoader;
    private VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += OnVideoEnd; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SkipCutscene()); 
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene()); 
    }

    IEnumerator SkipCutscene()
    {
        video.Stop(); // Stop the video playback
        yield return StartCoroutine(LoadNextScene()); 
    }

    IEnumerator LoadNextScene()
    {
        yield return StartCoroutine(levelLoader.SwitchScene()); 
    }
}
