using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//same principle as log
public class Car : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

   
}
