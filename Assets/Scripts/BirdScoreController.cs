using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScoreController : MonoBehaviour {

    public int Score = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PipeHolder") {
            Score +=1;
            SoundPlayerController.instance.playScoreSound();
        }
    }
}
