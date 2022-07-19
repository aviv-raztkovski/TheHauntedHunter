using System;
using UnityEngine;

public class ItemSwitchScript : MonoBehaviour
{
    public int selectedItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectItem();
    }

    // Update is called once per frame
    void Update()
    {
        int prevItem = selectedItem;
        if( Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            selectedItem++;
            selectedItem = selectedItem % 2;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            selectedItem--;
            selectedItem = Mathf.Abs(selectedItem) % 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedItem = 0;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedItem = 1;

        if (selectedItem != prevItem )
            selectItem();
    }
    private void selectItem()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
            if(i == selectedItem)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;
        }
    }
}
