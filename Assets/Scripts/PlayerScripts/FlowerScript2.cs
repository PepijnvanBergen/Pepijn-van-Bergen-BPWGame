using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript2 : MonoBehaviour
{
    public float flower;
    private SliderScript SC;
    private GameManager GM;

    private void Awake()
    {
        SC = GameObject.FindObjectOfType<SliderScript>();
        GM = GameObject.FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            SC.UpdateFlower();
            GM.UpdateFlower2();
            Destroy(gameObject);
        }
    }
}
