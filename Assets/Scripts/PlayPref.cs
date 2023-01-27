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
}
