using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    [SerializeField] public GameObject fuelCan;
    [SerializeField] public HeroScript hero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("OnTriggerEnter2D: FuelCan");
        hero.ImproveHealth(10f);
        fuelCan.SetActive(false);       
    }

}
