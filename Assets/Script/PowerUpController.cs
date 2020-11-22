using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(60, 100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
