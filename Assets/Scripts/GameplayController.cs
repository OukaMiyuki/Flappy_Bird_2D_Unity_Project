using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    [SerializeField] private Text scoreText, endScore, bestScore, gamePanelText;

    [SerializeField] private Button restartGameButton, instructionButton;

    [SerializeField] GameObject pausePanel;

    [SerializeField] GameObject[] birds;

    [SerializeField] private Sprite[] medals;

    [SerializeField] private Image medalImage;

    private void Awake() {
        MakeInstance();
        Time.timeScale = 0f; // set the time scale to 0 (pause the game) to show the instruction screen when the game is started
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public void PauseGame() { // this method assigned in the pause button in the gameplay scene
        if (BirdController.instance != null) {
            if (BirdDeathController.instance.isAlive) {
                pausePanel.SetActive(true); // show the panel
                gamePanelText.gameObject.SetActive(true); // show the text panel
                gamePanelText.text = "Pause"; // set the text panel to pause
                scoreText.gameObject.SetActive(false); // deactivate the score counter when play the game
                endScore.text = "" + BirdScoreController.instance.Score; // get the kast or end or current total score from score controller
                bestScore.text = "" + GameController.instance.GetHighScore(); // get the bset score from PlayerPrefs in the GameController
                Time.timeScale = 0f; // pause the game by set the time scale to 0
                restartGameButton.onClick.RemoveAllListeners(); // remove the listener of the button (because we'll gonna assign 2 listeners in the game, to resume the game when the game is paused and restart the game when the player is dead check line 111
                restartGameButton.onClick.AddListener(
                    () => ResumeGame() // assign the listener method
                );
            }
        }
    }

    public void GoToMenuButton() { // this method assigned in the Go To Menu button in the Gameplay scene
        ScreenFader.instance.FadeIn("MainMenu"); // load the scene by sending the scene name (check ScreenFader script)
    }

    public void ResumeGame() { // resume the game (line 46)
        pausePanel.SetActive(false); // deactivate the pause panel
        scoreText.gameObject.SetActive(true); // set the gameplay score tobe visible
        Time.timeScale = 1f; // resume the game by setting the time scale back to 1
    }

    public void PlayGame() { // this method assigned in the instruction button to start the gameplay when player touch or click the button
        scoreText.gameObject.SetActive(true); // show the score text
        birds[GameController.instance.GetSellectedBird()].SetActive(true); // enable the bird that sellected from the bird's menu sellection (check GameController)
        instructionButton.gameObject.SetActive(false); // deactivate or hide the instruction button
        Time.timeScale = 1f; // run the game
    }

    public void SetScore(int score) { // set the score text (check BirdScoreControlller script at line 24)
        scoreText.text = "" + score;
    }

    public void ShowPlayerDeathScore(int score) { // when player is dead (check BirdDeathController script at line 25)
        pausePanel.SetActive(true); // show the panel (btw pause and death are using the same panel)
        gamePanelText.gameObject.SetActive(true); // set the game panel to be visible
        gamePanelText.text = "Game Over"; // set the tect to be GameOver
        scoreText.gameObject.SetActive(false); // hide the gameplay score text

        endScore.text = "" + score; // get the endscore check comment at line 73

        if (score > GameController.instance.GetHighScore()) { // if the end score greater than the current best score (GameController.GetHighScore)
            GameController.instance.SetHighScore(score); // then assign the new best score
        }

        bestScore.text = "" + GameController.instance.GetHighScore(); // get the current high score from the GameController and show ot in the bestScore text inside the panel

        if (score <= 20) { // if you got 20 point
            medalImage.sprite = medals[0]; // then weee you got white medal
        } else if (score > 20 && score < 40) {
            medalImage.sprite = medals[1];

            if (GameController.instance.IsGreenBirdUnlocked() == 0) { // then check if the green bird is locked
                GameController.instance.UnlockGreenBird(); // then unlock the bird (now the green bird is playable)
            }
        } else {
            medalImage.sprite = medals[2];

            if (GameController.instance.IsGreenBirdUnlocked() == 0) {
                GameController.instance.UnlockGreenBird();
            }

            if (GameController.instance.IsRedBirdUnlocked() == 0) {
                GameController.instance.UnlockredBird();
            }
        }

        restartGameButton.onClick.RemoveAllListeners(); // remove listsner check comments at line 44
        restartGameButton.onClick.AddListener(
            () => RestartGame() // restart the game
        );
    }

    public void RestartGame() { // weeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee I'm flying!!!!!!!!!!!!!
        ScreenFader.instance.FadeIn(SceneManager.GetActiveScene().name);
    }
}
