using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboarddScript : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject firstPersonCam;

    Transform activeCam;
    void LateUpdate()
    {
        if (thirdPersonCam.activeInHierarchy)
            activeCam = thirdPersonCam.transform;
        else
            activeCam = firstPersonCam.transform;
        transform.LookAt(transform.position + activeCam.forward);
    }
}
