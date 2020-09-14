using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerController : MonoBehaviour {

    // I guess I don't need to explain what these line of codes are actually doing, it obvious to be understanable easily

    public static SoundPlayerController instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flapClick, pointClip, dieClip;

    private void Awake() {
        if (instance == null) { // if the instance is null, initialise this class
            instance = this;
        }
    }

    public void playFlapSound() {
        audioSource.PlayOneShot(flapClick);
    }

    public void playScoreSound() {
        audioSource.PlayOneShot(pointClip);
    }

    public void playDeathSound() {
        audioSource.PlayOneShot(dieClip);
    }

}
