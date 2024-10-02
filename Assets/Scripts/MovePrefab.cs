using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    [SerializeField] public GameObject prefabToMove;
    [SerializeField] public GameObject currentPrefab;
    public float incrementX;

    [SerializeField] public GameObject fuelCan;
    [SerializeField] public GameObject laser;

    void OnTriggerEnter2D()
    {

        //print("Move Prefab: " + currentPrefab.tag);
        //Vector3 temp = currentPrefab.transform.position;
        //temp.x = temp.x + incrementX;
        //prefabToMove.transform.position = temp;

        //print("MoveDirection: " + HeroScript.moveDirection + ", Facing Right: " + HeroScript.facingRight);

        if (HeroScript.moveDirection > 0 && HeroScript.facingRight)
        {
            //print("Move Prefab Condition 1: " + HeroScript.moveDirection + ", " + HeroScript.facingRight);
            Vector3 temp = currentPrefab.transform.position;
            temp.x = temp.x + incrementX;
            prefabToMove.transform.position = temp;
        }
        else if (HeroScript.moveDirection < 0 && !HeroScript.facingRight)
        {
            //print("Move Prefab Condition 2: " + HeroScript.moveDirection + ", " + HeroScript.facingRight);
            Vector3 temp = currentPrefab.transform.position;
            temp.x = temp.x - incrementX;
            prefabToMove.transform.position = temp;
        }

        int choice = Random.Range(0, 2);
        if (choice == 0)
        {
            fuelCan.SetActive(true); 
            laser.SetActive(false);            
        }
        else if (choice == 1)
        {
            fuelCan.SetActive(false); 
            laser.SetActive(true);            
        }
    }

}
