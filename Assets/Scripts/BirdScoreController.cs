using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScoreController : MonoBehaviour {

    public static BirdScoreController instance;

    public int Score = 0;

    private void Awake() {
        MakeInstance();
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PipeHolder") {
            Score +=1;
            GameplayController.instance.SetScore(Score); // set the current score by incrementting the score variable
            SoundPlayerController.instance.playScoreSound();
        }
    }
}
