﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitBoxHandler : MonoBehaviour {

    public List<GameObject> digitBoxes = new List<GameObject> ();
    private List<GameObject> addedDigitBoxes = new List<GameObject> ();

    public int direction = 1;

    private int gridSize = 25;

    private int startPosx = 440;
    private int startPosy = 500;

    public int atCurrX = 0;
    public int atCurrY = 0;

    void Start () {
        atCurrX = startPosx;
        atCurrY = startPosy;
    }

    private void CleanDigitBoxes () {
        for (int i = 0; i < addedDigitBoxes.Count; i++) {
            Destroy (addedDigitBoxes[i]);
        }
        addedDigitBoxes.Clear ();
    }

    public void changeDirection () {
        direction *= -1;
    }

    public void oneRowDown (int digit) {
        atCurrY -= gridSize;
        changeDirection ();
        //don't move in x dir
        addNextNumber (digit, false);
    }

    public void addNextNumber (int digit, bool add = true) {

        if (add) {
            atCurrX -= direction * gridSize;
        }
        //instantiate
        GameObject added = Instantiate (digitBoxes[digit], new Vector3 (atCurrX, atCurrY, 0), Quaternion.identity);
        //add to list
        addedDigitBoxes.Add (added);
    }
}