using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 40;
    public GameObject player;
    public float thrust = 1500f;
    public Rigidbody rb;
    public float damage = 15;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += player.transform.forward * speed * Time.deltaTime;
        Destroy(this.gameObject, 2f);
    }
}
