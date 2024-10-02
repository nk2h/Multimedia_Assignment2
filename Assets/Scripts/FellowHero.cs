using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowHero : MonoBehaviour
{
    [SerializeField] public GameObject heroCopy;

    void Update()
    {
        //print("Fellow Hero");
        //print("Transform: " + transform.position.x + ", Copy: " + heroCopy.transform.position.x);

        if (heroCopy.transform.position.x > transform.position.x)
        {
            //print("Inside Validation");
            transform.position = new Vector3(heroCopy.transform.position.x - 3, transform.position.y, transform.position.z);
        }
    }
}
