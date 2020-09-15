using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    [SerializeField] private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;

    private void Awake() {
        MakeInstance();
    }

    void Start() {
        birds[GameController.instance.GetSellectedBird()].SetActive(true); // get the current sellected bird when the game run
        CheckBirdsUnlocked();
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlayTheGame() {
        ScreenFader.instance.FadeIn("Gameplay"); // pass the scene name to Screenfader.FadeIn
    }

    private void CheckBirdsUnlocked() { // the method's name is obvious, right?
        if (GameController.instance.IsRedBirdUnlocked() == 1) { // you know where to go, GameController.IsRedBirdUnlocked()
            isRedBirdUnlocked = true;
        }

        if(GameController.instance.IsGreenBirdUnlocked() == 1) { // weeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            isGreenBirdUnlocked = true;
        }
    }

    public void ChangeBird() { // this assigned to thje sellect bird button on the scene
        if (GameController.instance.GetSellectedBird() == 0) { // if the current sellected bird is 0 (meaning the blue bid) then the next sellected bird if the button is clicked is 2nd bird or the green bird
            if (isGreenBirdUnlocked) { // but before that check the green bird status, is it unlocked already? or not (line 32)
                birds[0].SetActive(false); // then set the bird at index 0 (the current sellected bird) to be actively false
                GameController.instance.SetSellectedBird(1); // set the sellected bird to the second index of the array (1) or you can say the green bird
                birds[GameController.instance.GetSellectedBird()].SetActive(true); // set the second bird's game object to be actived
            }
        } else if (GameController.instance.GetSellectedBird() == 1) { // well this one's basically similar with the previous condition, but for the next bird, you can easily understand this one, just read the code carefully if you don't get it
            if (isRedBirdUnlocked) {
                birds[1].SetActive(false);
                GameController.instance.SetSellectedBird(2);
                birds[GameController.instance.GetSellectedBird()].SetActive(true);
            } else {
                birds[1].SetActive(false);
                GameController.instance.SetSellectedBird(0);
                birds[GameController.instance.GetSellectedBird()].SetActive(true);
            }
        } else if (GameController.instance.GetSellectedBird() == 2) { // do I need to explain these lines of codes? read the comment at line 49 and gotcha!
            birds[2].SetActive(false);
            GameController.instance.SetSellectedBird(0);
            birds[GameController.instance.GetSellectedBird()].SetActive(true);
        }
    }

}
