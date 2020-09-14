using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimationController : MonoBehaviour {

    // well it has the same purpose as the SoundPlayerController, so yeah, just re-visit the code and you'll get it

    public static BirdAnimationController instance;

    [SerializeField] private Animator birdAnimation;

    private void Awake() {
        if (instance == null) { // if the instance is null, initialise this class
            instance = this;
        }

    }

    public void playFlapAnimation() {
        birdAnimation.SetTrigger("Flap");
    }

    public void playDeadAnimation() {
        birdAnimation.SetTrigger("BirdDie");
    }
}
