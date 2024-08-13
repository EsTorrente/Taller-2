using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;

    public IEnumerator LoadTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
    }

    public IEnumerator SwitchScene()
    {
        yield return StartCoroutine(LoadTransition());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
