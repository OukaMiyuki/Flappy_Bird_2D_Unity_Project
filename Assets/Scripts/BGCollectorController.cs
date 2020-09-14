using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollectorController : MonoBehaviour {

    private GameObject[] backgrounds; //initialize array of gameobjects
    private GameObject[] grounds; //initialize array of gameobjects

    private float lastBGX;
    private float lastGRX;

    void Awake() {
        backgrounds = GameObject.FindGameObjectsWithTag("Background"); // find game objects with the tag name of Background
        grounds = GameObject.FindGameObjectsWithTag("Ground"); // find game objects with the tag name of Ground

        lastBGX = backgrounds[0].transform.position.x; // initialize the lastBGX to the first array position of the backgrounds array
        lastGRX = grounds[0].transform.position.x; // Has the same purpose as lastBGX but for the ground items

        for (int i=1; i < backgrounds.Length; i++) { // loop with the length of backgrounds array
            if (lastBGX < backgrounds[i].transform.position.x) { // basically this is similar to the bubble sort mechanism, it will keep looping and search for the highest value within the array
                lastBGX = backgrounds[i].transform.position.x; // then after it is true then initialize it for lastBGX
            }
        }

        for (int i = 1; i < grounds.Length; i++) { // well, no need to explain, basically the same as the previous loop but for the ground items
            if (lastGRX < grounds[i].transform.position.x) {
                lastGRX = grounds[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) { // when the BGCollector collide with either background or the ground (don't forget to check the collider settings in the project settings)
        if (collision.tag == "Background") { // if it collides with the background
            print("Walla background"); // don't mind it just a test print
            Vector3 temp = collision.transform.position; // get the transform position os the collided item
            float colObjectWidth = ((BoxCollider2D)collision).size.x; // get the width of the collided item (or in this case is the background item)
            temp.x = lastBGX + colObjectWidth; // set the x posisition of the temp to the lastBGX+background width (basically it's like you move the first item to the last position)
            collision.transform.position = temp; // the execute the transform or move the object (the background)
            lastBGX = temp.x; // update the lastBGX value
        } else if (collision.tag == "Ground") { // well it's basically the same again but for the ground
            print("Walla ground");
            Vector3 temp = collision.transform.position;
            float colObjectWidth = ((BoxCollider2D)collision).size.x;
            temp.x = lastGRX + colObjectWidth;
            collision.transform.position = temp;
            lastGRX = temp.x;
        }
    }
}
