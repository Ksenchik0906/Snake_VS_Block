using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPref : MonoBehaviour
{
    Transform _transform;
    Rigidbody _rb;
    public Transform Player;
    Vector3 _moveY;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        Player = GetComponent<Transform>();
        _moveY = new Vector3(0f, 0f, 2f);
    }

    
    void FixedUpdate()
    {
     //  _rb.AddForce(_moveY, ForceMode.Force);

        //_transform.position = new Vector3(Player.position.x, 0.5f, Player.position.z + 0.04f);
        //  Vector3 play = new Vector3(_transform.position.x, 0.5f, Player.position.z);
        //  _transform.Translate(play); 
        //  
    }
}
