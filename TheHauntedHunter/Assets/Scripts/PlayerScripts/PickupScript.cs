using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public WhiskeyScript playerWhiskey;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerWhiskey.addWhiskey();
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.2f); //waits 3 seconds
        Destroy(gameObject); //this will work after 3 seconds.
    }
}
