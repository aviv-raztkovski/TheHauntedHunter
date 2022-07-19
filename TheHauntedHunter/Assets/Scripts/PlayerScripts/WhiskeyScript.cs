using UnityEngine;

public class WhiskeyScript : MonoBehaviour
{
    public float healAmount = 20f;
    public float drinkRate = 1f;
    public int whiskeyAmount = 1;

    public EntityHealthScript healthScript;

    private float nextTimeToDrink = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToDrink && whiskeyAmount > 0)
        {
            nextTimeToDrink = Time.time + 1 / drinkRate;
            drink();
        }
    }

    void drink()
    {
        whiskeyAmount--;
        transform.GetComponent<AudioSource>().Play();
        healthScript.heal(healAmount);
    }

    public void addWhiskey()
    {
        whiskeyAmount++;
    }
}
