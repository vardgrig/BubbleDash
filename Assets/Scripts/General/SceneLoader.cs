using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public static class SceneLoader
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static IEnumerator LoadSceneAsync(string sceneName, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}