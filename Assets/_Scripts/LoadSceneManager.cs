using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Scripts
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        [SerializeField] private Animator animator;
        
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadGame(sceneName));
        }

        private IEnumerator LoadGame(string sceneName)
        {
            animator.SetTrigger("Start");
            yield return new WaitForSeconds(1f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;
        
            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    break;
                }
                yield return null;
            }
        
            asyncLoad.allowSceneActivation = true;
        
            yield return new WaitUntil(() => asyncLoad.isDone);
            animator.SetTrigger("End");
        }
    }
}