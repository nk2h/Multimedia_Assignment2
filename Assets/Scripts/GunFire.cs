using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform bulletPos;

    [SerializeField] private GameObject heroPlayer;
    private float timer;

    private void Start()
    {
        heroPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //print("Gun Fire");   
        float distance = Vector2.Distance(transform.position, heroPlayer.transform.position);
        //print(distance);
        if(distance < 12)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                BulletFire();
            }
        }        
    }
    
    void BulletFire()
    {
        //print(Quaternion.identity.x + ", " + Quaternion.identity.y + ", " + Quaternion.identity.z);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);        
    }
    
}
