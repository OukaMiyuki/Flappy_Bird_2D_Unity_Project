using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static float offsetX; // check BirdController SetCameraOffsetX

    void Start() {
        
    }

    void Update() { // this method will run for each frame of the game
        if (BirdController.instance != null) {
            if (BirdDeathController.instance.isAlive) { // if the player or the bird still alive
                MoveTheCamera(); // then move the camera
            }
        }
    }

    private void MoveTheCamera() {
        Vector3 temp = transform.position; // get the transform position of the camera
        temp.x = BirdController.instance.GetPlayerPositionX() + offsetX; // get the bird position and add it with the offsetX value
        transform.position = temp; // transform the camera
    }
}
