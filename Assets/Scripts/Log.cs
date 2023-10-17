using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls log flow with the speed set in the inspector
public class Log : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

