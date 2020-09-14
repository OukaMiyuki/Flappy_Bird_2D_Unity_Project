using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour {

    public static BirdController instance; // create static method, so you don't need to initalize an object to call the class

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float forwardSpeed = 3f;
    [SerializeField] private float bounceSpeed = 4f;

    private Button flapButton;
    private bool didFlap; // flap state

    private void Awake() {
        if (instance == null) { // if the instance is null, initialise this class
            instance = this;
        }

        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>(); //initialize flapButton as gameobject with tag "FlapButton"
        flapButton.onClick.AddListener( // add onclick listener
            () => FlapTheBird()
        );
        SetCameraOffsetX();
    }

    void Start() {

    }

    private void FixedUpdate() {
        if (BirdDeathController.instance.isAlive) { // if player is alive
            Vector3 temp = transform.position; // get the current position of the bird / player
            temp.x += forwardSpeed * Time.deltaTime; // add horizontal movement by increment the temp.x based on forward speed and relative to time.deltatime
            transform.position = temp; // transform the bird or player (move it horizontally)

            if (didFlap) { // if bird flap state is true
                SoundPlayerController.instance.playFlapSound();
                didFlap = false; // disable flap after it clicked (when it bounced)
                rb.velocity = new Vector2(2, bounceSpeed); // add velocity x = 2, y = bounceSpeed
                BirdAnimationController.instance.playFlapAnimation(); // play bird's flap animation
            }
        } else {
            print("Walla mati");
            return;
        }

        if (rb.velocity.y >= 0) { // if the bird bounced, or the y velocity is up towards (the bird is clicked the it bounce)
            transform.rotation = Quaternion.Euler(0, 0, 0); // set the rotation to 0 
        } else {  // if the bird fall or not clicked
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -rb.velocity.y / 7); // rotate the bird -90° (clock wise) from 0° with period of time within the valuse of -rb.velocity.y/7
            transform.rotation = Quaternion.Euler(0, 0, angle); // rotate the bird base on angle with mathf.lerp
            // Read More : https://answers.unity.com/questions/237294/how-the-heck-does-mathflerp-work.html#:~:text=Basically%2C%20lerp%20stands%20for%20linear,0.5%20will%20be%20halfway%20between.
            // Read More : https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        }
    }

    private void FlapTheBird() { // make it public so it can be called outside class
        didFlap = true; // iniciate the flap to true
    }

    private void SetCameraOffsetX(){ // method to set camera offset
        CameraController.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f; // initialize the value of offsetX inside Camera COntroller
    }

    public float GetPlayerPositionX() { // function to get player or bird position
        return transform.position.x;
    }
}
