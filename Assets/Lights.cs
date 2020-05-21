using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject[] gameObjectsArray;
    public GameObject globalLight;
 
    public void ToggleLights(bool state) 
    {
        foreach(GameObject go in gameObjectsArray)
        {
                go.SetActive (state);   
        }
    }

    public void ToggleGlobal(bool state) 
    {
        if ( globalLight.activeSelf == true){
            globalLight.SetActive(false);
        } else {
            globalLight.SetActive(true);
        }
    }
}
