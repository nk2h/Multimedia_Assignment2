using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject heroPlayer;
    //private GameObject gun;
    [SerializeField] private Rigidbody2D rb;
    private float speed = 4.5f;
    private float destroyTimer;

    public AudioClip bulletHit;
    public AudioClip gunlight;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heroPlayer = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AudioSource>().PlayOneShot(bulletHit, 1.5F);
        //gun = GameObject.FindGameObjectWithTag("Gun");

        Vector3 bulletDirection = heroPlayer.transform.position - transform.position;
        //print(bulletDirection.magnitude);
        rb.velocity = new Vector2(bulletDirection.x, bulletDirection.y).normalized * speed;
        GetComponent<AudioSource>().PlayOneShot(bulletHit);
    }

    // Update is called once per frame
    private void Update()
    {
        destroyTimer += Time.deltaTime;
        if(destroyTimer > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HeroScript>().ReduceHealth(0.5f);
            Destroy(gameObject);
        }
    }
}
