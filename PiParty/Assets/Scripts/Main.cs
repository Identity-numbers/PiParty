using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private int maxTesting = 10000;

    public DigitBoxHandler digitBoxHandler;
    public Constants constants;

    /*

    What do I need to do?

    Add sqrt2 and numbers that are known not to be clean
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
    }

    public void MainFunction () {

        for (int i = 1; i < maxTesting; i++) {
            //int digit = constants.PhiDigits[i];
            //int digit = constants.PiDigits[i];
            int digit = constants.EDigits[i];
            //make a test criterion
            if (digit == 3) {
                //move down one row
                    //change direction
                digitBoxHandler.oneRowDown(digit);

            }else{
                digitBoxHandler.addNextNumber(digit);
            }

            //if number is 3, go down one row and change direction
        }
    }
}