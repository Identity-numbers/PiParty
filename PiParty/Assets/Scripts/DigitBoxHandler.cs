using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitBoxHandler : MonoBehaviour {

    public List<GameObject> digitBoxes = new List<GameObject> ();
    public List<GameObject> addedDigitBoxes = new List<GameObject> ();

    public int direction = 1;

    private int gridSize = 9;

    private int startPosx = 440;
    private int startPosy = 1800;

    public int atCurrX = 0;
    public int atCurrY = 0;

    void Start () {
        ResetStartPosition();
    }

    public void ResetStartPosition(){
        direction = 1;
        atCurrX = startPosx;
        atCurrY = startPosy;
    }

    public void CleanDigitBoxes () {
        for (int i = 0; i < addedDigitBoxes.Count; i++) {
            Destroy (addedDigitBoxes[i]);
        }
        addedDigitBoxes.Clear ();
        ResetStartPosition();
    }

    public void changeDirection () {
        direction *= -1;
    }

    public void oneRowDown (int digit, int atIndex) {
        atCurrY -= gridSize;
        changeDirection ();
        //don't move in x dir
        addNextNumber (digit, atIndex, false);
    }

    public void addNextNumber (int digit, int atIndex, bool add = true) {

        if (add) {
            atCurrX -= direction * gridSize;
        }
        //instantiate
        GameObject added = Instantiate (digitBoxes[digit], new Vector3 (atCurrX, atCurrY, 0), Quaternion.identity);
        added.name = added.name + "_" + atIndex;
        //add to list
        addedDigitBoxes.Add (added);
    }
}