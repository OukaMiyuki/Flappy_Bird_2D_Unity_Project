using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    // set the game state for every components, like birds unlock status, scores, high scores, sellected bird etc.
    private const string highScore = "High Score";
    private const string selectedBird = "Selected Bird";
    private const string greenBird = "Green Bird";
    private const string redBird = "Red Bird";

    void Awake() {
        MakeSinglton();
        IsTheGameHasAlreadyStartedBefore();
    }

    private void MakeSinglton() {
        if (instance != null) {
            Destroy(gameObject); // Destroy if gameobject has already exists
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void IsTheGameHasAlreadyStartedBefore() { //this method basically check if the player has already open and play the game before
        if (!PlayerPrefs.HasKey("IsTheGameHasAlreadyStartedBefore")) { // if the game run for the first time then all the data will be on this condition
            PlayerPrefs.SetInt(highScore, 0); // set the high score to 0
            PlayerPrefs.SetInt(selectedBird, 0); // the sellected bird assigned to the fiorst bird in the array order (0)
            PlayerPrefs.SetInt(greenBird, 1);
            PlayerPrefs.SetInt(redBird, 1);
            PlayerPrefs.SetInt("IsTheGameHasAlreadyStartedBefore", 0);
        } else { 
        
        }
    }

    public void SetHighScore(int score) { // set the current high score, check GameplayController
        PlayerPrefs.SetInt(highScore, score);
    }

    public int GetHighScore() {
        return PlayerPrefs.GetInt(highScore);
    }

    public void SetSellectedBird(int SelectedBird) { // set sellected bird, check MenuController.ChangeBird()
        PlayerPrefs.SetInt(selectedBird, SelectedBird);
    }

    public int GetSellectedBird() { // get the sellected bird in PlayerPrefs
        return PlayerPrefs.GetInt(selectedBird);
    }

    public void UnlockGreenBird() {
        PlayerPrefs.SetInt(greenBird, 1);
    }

    public int IsGreenBirdUnlocked() {
        return PlayerPrefs.GetInt(greenBird);
    }

    public void UnlockredBird() {
        PlayerPrefs.SetInt(redBird, 1);
    }

    public int IsRedBirdUnlocked() {
        return PlayerPrefs.GetInt(redBird);
    }
}
