using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeathController : MonoBehaviour {

    public static BirdDeathController instance;
    public bool isAlive; // bird or player alive state


    private void Awake() {
        if (instance == null) { // if the instance is null, initialise this class
            instance = this;
        }

        isAlive = true; // player is alive when isAlive is true
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Pipe") {
            if (isAlive) {
                isAlive = false;
                BirdAnimationController.instance.playDeadAnimation();
                SoundPlayerController.instance.playDeathSound();
            }
        }
    }
}
