using System.Collections;
using UnityEngine;

public class nextScene : MonoBehaviour
{
    public levelLoader levelLoader;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return StartCoroutine(levelLoader.SwitchScene());
    }
}
