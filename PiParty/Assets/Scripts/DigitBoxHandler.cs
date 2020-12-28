using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitBoxHandler : MonoBehaviour {

    public GameObject GOParent;
    public Toggle toggleRotation;
    public GORotation goRotation;

    public List<GameObject> digitBoxes = new List<GameObject> ();
    public List<GameObject> addedDigitBoxes = new List<GameObject> ();

    public int direction = 1;

    private int gridSize = 9;

    private int startPosx = 440;
    private int startPosy = 1800;
    private int startPosz = 0;

    public int atCurrX = 0;
    public int atCurrY = 0;

    // 3D variables ==================================
    private int UpDownDir = 1;
    private int RightLeft = 1;
    private int ForwBackW = 1;

    private int at3D_CurrX = 0;
    private int at3D_CurrY = 0;
    private int at3D_CurrZ = 0;
    // ==================================

    void Start () {
        //reset and set all positions
        ResetStartPosition ();
        ResetDir3DPositions();

        //toggleRotation = toggleRotation.GetComponent<Toggle>();
        toggleRotation.onValueChanged.AddListener (delegate {
            ToggleValueChanged (toggleRotation);
        });
    }

    private void ToggleValueChanged (Toggle change) {
        goRotation.setToggleValue (change.isOn);
    }

    public void ResetStartPosition () {
        direction = 1;
        atCurrX = startPosx;
        atCurrY = startPosy;
    }

    public void CleanDigitBoxes () {
        for (int i = 0; i < addedDigitBoxes.Count; i++) {
            Destroy (addedDigitBoxes[i]);
        }
        addedDigitBoxes.Clear ();
        ResetStartPosition ();
    }

    // 2D functions ==========================================

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
        added.transform.SetParent (GOParent.transform);
        added.name = added.name + "_" + atIndex;
        //add to list
        addedDigitBoxes.Add (added);
    }

    // 3D functions ==========================================
    public void ResetDir3DPositions () {
        at3D_CurrX = startPosx;
        at3D_CurrY = startPosy;
        at3D_CurrZ = startPosz;

        UpDownDir = RightLeft = ForwBackW = 1;
    }

    public void MoveUpDown () {
        //toggle dir

    }

    public void MoveLeftRight () {
        //toggle dir
    }

    public void MoveForwBackw () {
        //toggle dir
    }
}