using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraScript : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject Player;
    public int camMode;

    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (camMode == 1)
                camMode = 0;
            else if (camMode == 0)
                camMode = 1;
            StartCoroutine(camChange());
        }
    }

    IEnumerator camChange()
    {
        yield return new WaitForSeconds(.01f);
        if(camMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
            Player.GetComponent<FirstPersonMovementScript>().enabled = false;
            Player.GetComponent<ThirdPersonControllerScript>().enabled = true;
        }
        else if (camMode == 1)
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
            Player.GetComponent<FirstPersonMovementScript>().enabled = true;
            Player.GetComponent<ThirdPersonControllerScript>().enabled = false;
        }
    }
}
