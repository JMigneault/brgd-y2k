using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInstructions : MonoBehaviour
{

    public GameObject instructions;
    public GameObject cabinet;
    public GameObject left;
    public GameObject right;

    public void Show() {
        if (instructions.active) {
            cabinet.SetActive(true);
            left.SetActive(true);
            right.SetActive(true);
            instructions.SetActive(false);

        } else {
            instructions.SetActive(true);
            cabinet.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);
        }
    }

}
