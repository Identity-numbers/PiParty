using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    //camera
    public CameraMultiTarget cameraMultiTarget;
    private int atTarget = 0;
    private int stepTargetSize = 500;

    //dropdown menus
    public Dropdown myDropdownConst;
    // 0 - Pi
    // 1 - E
    // 2 - Phi
    public Dropdown myDropdownTestCase;
    //@1-Row Down and change dir
    //@2-Row Down and change dir
    //@3-Row Down and change dir

    //max 10000 digits so far
    private int maxTesting = 1500;

    public DigitBoxHandler digitBoxHandler;
    public Constants constants;

    /*

    What do I need to do?

    Add sqrt2 and perhaps numbers that are known not to be clean
    move all digit boxes to a parent
    make a remove function for all digitboxes

    add a tool that handles the positioning and spacing of digit boxes
    add a button for each test criterion
    a dropdown list for if statements?
    add a camera so a web user can look at the structure

    */

    // Start is called before the first frame update
    void Start () {

        MainFunction ();

        myDropdownConst.onValueChanged.AddListener (delegate {
            myDropdownValueChangedHandler (myDropdownConst);
        });
        myDropdownTestCase.onValueChanged.AddListener (delegate {
            myDropdownValueChangedHandler (myDropdownTestCase);
        });

        //StartCoroutine(Countdown(1));
    }

    //clean up listeners on scene destroy?
    void Destroy () {
        myDropdownConst.onValueChanged.RemoveAllListeners ();
        myDropdownTestCase.onValueChanged.RemoveAllListeners ();
    }

    private void myDropdownValueChangedHandler (Dropdown target) {
        Debug.Log ("selected: " + target.value);
    }

    public void SetDropdownIndexConst (int index) {
        myDropdownConst.value = index;
    }
    public void SetDropdownIndexTestCase (int index) {
        myDropdownTestCase.value = index;
    }

    public void MainFunction () {
        atTarget = 0;
        //clean digit boxes
        digitBoxHandler.CleanDigitBoxes ();
        //set dropdown constant
        List<int> ListDigits = new List<int> ();

        if (myDropdownConst.value == 0) {
            ListDigits = new List<int> (constants.PiDigits);
        } else if (myDropdownConst.value == 1) {
            ListDigits = new List<int> (constants.EDigits);
        } else if (myDropdownConst.value == 2) {
            ListDigits = new List<int> (constants.PhiDigits);
        }

        //testcase between 0-9
        if (myDropdownTestCase >= 0 && myDropdownTestCase <= 9) {
            for (int i = 1; i < maxTesting; i++) {

                int digit = ListDigits[i];
                //make a test criterion
                if (digit == myDropdownTestCase.value) {
                    //move down one row
                    //change direction
                    digitBoxHandler.oneRowDown (digit, i);

                } else {
                    digitBoxHandler.addNextNumber (digit, i);
                }
            }
        } else if (myDropdownTestCase > 9 && myDropdownTestCase == 10) {
            for (int i = 1; i < maxTesting; i++) {
                //pick up the digit list
                int digit = ListDigits[i];

                if (digit == 1) {

                } else if (digit == 2) {

                } else if (digit == 3) {

                }
            }

        }

        SetTargets ();
        //Countdown (1);
    }

    void SetTargets () {
        // Whatever you want to happen when the countdown finishes
        //add first 100 to camera?
        if (atTarget >= maxTesting - stepTargetSize) {
            atTarget = 0;
        }
        //cameraMultiTarget.ClearTargets();
        //cameraMultiTarget.SetTargets (digitBoxHandler.addedDigitBoxes.Skip (atTarget).Take (stepTargetSize).ToArray ());
        cameraMultiTarget.SetTargets (digitBoxHandler.addedDigitBoxes.ToArray ());
        atTarget += stepTargetSize;
        //StartCoroutine(Countdown(1));
    }

    /*
        private IEnumerator Countdown (int seconds) {
            int counter = seconds;
            while (counter > 0) {
                yield return new WaitForSeconds (1);
                counter--;
            }
            SetTargets ();
        }
        */
}