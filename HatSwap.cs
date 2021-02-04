using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSwap : MonoBehaviour
{
    //An array of all the hats
    public GameObject[] hats;

    //the object that holds the hat (this object is the spawn position and the parent of the hat)
    public GameObject hatHolder;

    //here we can store the current hat GameObject so we can destroy it later, this is made public so other scripts can acces it. Do not change thhis value from another script!
    public GameObject currentHatObject;

    //here we store the current hat interger so we can switch hats, this is made public so other scripts can change it.
    public int currentHat;

    public void NextHat()
    {
        //destroy the current hat
        Destroy(currentHatObject);

        if (currentHat == hats.Length - 1)
        {
            //setting the currentHat back to 0 if the selected hat is the last hat
            currentHat = 0;
        } else
        {
            //adding 1 to currentHat if it is under the last GameObject in the hats array
            currentHat++;
        }

        //adding the new hat from the hats array
        currentHatObject = Instantiate(hats[currentHat], hatHolder.transform);
    }

    public void PreviousHat()
    {
        //destroy the current hat
        Destroy(currentHatObject);
        if (currentHat == 0)
        {
            //setting the currentHat to the last hat if the first hat is selected
            currentHat = hats.Length - 1;
        }
        else
        {
            //removing 1 from currentHat if currentHat is above the first hat
            currentHat--;
        }
        //adding the new hat from the hats array
        currentHatObject = Instantiate(hats[currentHat], hatHolder.transform);
    }


    //you have to activate this function if you changed the currentHat from script without using the PreviousHat or NextHat function
    public void UpdateHat()
    {
        //destroy the current hat
        Destroy(currentHatObject);
        //adding the new hat from the hats array
        currentHatObject = Instantiate(hats[currentHat], hatHolder.transform);
    }

    //you can remove the Update funcion, I added this for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextHat();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousHat();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateHat();
        }
    }

    private void Start()
    {
        //adding the new hat from the hats array
        currentHatObject = Instantiate(hats[currentHat], hatHolder.transform);
    }

}
