using UnityEngine;
using System.Collections; //IEnumerator and coroutines
using UnityEngine.SceneManagement; //LoadScene

public class BGMSceneTransition : MonoBehaviour
{
    [Header("BGM Settings")] //display in inspector
    public AudioSource bgm;
    public float fadeDuration = 1.5f; //Time taken for BGM to fade out

    [Header("Scene Settings")]
    public string nextSceneName = "Scene2";

    private bool isTransitioning = false; //avoid multiple transition

    public void LoadSceneByName()
    {
        if(isTransitioning) return;
        StartCoroutine(FadeOutAndLoadScene()); //fades out the music before load next scene
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        isTransitioning = true;

        //smoothly decrease volume of current BGM
        if (bgm != null && bgm.isPlaying)
        {
            float startVolume = bgm.volume;
            float timer = 0f;

            if (fadeDuration > 0f)
            {
                while (timer < fadeDuration) //keep doing this until timer is no longer smaller than fadeduration
                {
                    timer += Time.unscaledDeltaTime;
                    bgm.volume = Mathf.Lerp (startVolume, 0f, Mathf.Clamp01(timer/fadeDuration)); //(volume at begining, target volume, clamps fade progress between 0 and 1)

                    yield return null; // waits until the next frame before continuing the coroutine
                }
            }

            bgm. volume = 0f; // ensure volume reaches 0
            bgm. Stop();
        }

            SceneManager.LoadScene(nextSceneName);
    }


}
