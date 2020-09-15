using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour {

    public static ScreenFader instance;

    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private Animator fadeAnim;

    private void Awake() {
        MakeSingleton();
    }

    void Start() {
        
    }

    private void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else{
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void FadeIn(string levelName) {
        StartCoroutine(FadeInAnimation(levelName)); // load the scene based on the scene name with coroutine
        //Read More : https://unitycsharp.blogspot.com/2015/09/unity-c-tutorial-indonesia-basic-14.html#:~:text=Salah%20satu%20fungsi%20dari%20coroutine,baris%20perintah%20yang%20akan%20diproses.&text=Penjelasan%20%3A&text=yield%20return%20new%20WaitForSecond%20digunakan%20untuk%20memberi%20jeda%20waktu%20per%20detik.
    }

    IEnumerator FadeInAnimation(string LevelName) {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeIn Animation");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f)); // return another coroutine from another coroutine in another class
        SceneManager.LoadScene(LevelName); // load scene process
        //FadeOut(); // fadeout after fade in
        StartCoroutine(FadeOutAnimation());
    }

    // well you have 2 options to fade out
    //public void FadeOut() { // fade out after fade in
    //    StartCoroutine(FadeOutAnimation());
    //}

    IEnumerator FadeOutAnimation() {
        fadeAnim.Play("FadeOut Animation");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        fadeCanvas.SetActive(false);
    }
}
