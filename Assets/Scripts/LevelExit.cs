using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] private CapsuleCollider2D bodyCollider;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D) // beacause player has two collider 
        {
            Debug.Log("===");
        }
        StartCoroutine(LoadNextLevel());
        Debug.Log("load xin");

    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindFirstObjectByType<ScencePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
