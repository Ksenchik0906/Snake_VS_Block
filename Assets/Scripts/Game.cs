using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Rigidbody _rb;
    public float _sp;
    Vector3 _moveY;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveY = new Vector3(0f, 0f, -150f);
    }

    // Update is called once per frame
    void Update()
    {
      //  _rb.velocity = new Vector3(0, 0, -1f) * _sp;
        _rb.AddForce(_moveY, ForceMode.Acceleration);
    }
}
