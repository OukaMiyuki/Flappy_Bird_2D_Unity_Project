using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour {

    private GameObject[] pipeHolders;
    private float distance = 3f;
    private float lastPipeX;
    private float pipeMin = -1.5f;
    private float pipeMax = 2.5f;

    private void Awake() {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for (int i = 0; i<pipeHolders.Length; i++) {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }

        //int lastIndex = pipeHolders.Length - 1;

        //lastPipeX = pipeHolders[lastIndex].transform.position.x;

        lastPipeX = pipeHolders[0].transform.position.x;
       for (int i = 0; i< pipeHolders.Length; i++) {
            if (lastPipeX < pipeHolders[i].transform.position.x) {
                lastPipeX = pipeHolders[i].transform.position.x;
            }
       }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PipeHolder") {
            Vector3 temp = collision.transform.position;
            temp.x = lastPipeX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);
            collision.transform.position = temp;
            lastPipeX = temp.x;
        }
    }
}
