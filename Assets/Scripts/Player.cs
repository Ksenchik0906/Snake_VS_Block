using UnityEngine;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System;
=======
using TMPro;
>>>>>>> Stashed changes

public class Player : MonoBehaviour
{
    Transform _player;
    Rigidbody _rb;
    Vector3 _moveY;
    float _speed = 5f;
    float moveX;
    int _hp;
    int ii = 1;

    public Vector2 BorderX, BorderY;
    public Transform Camera;
    public int Hp;
<<<<<<< Updated upstream
    public Bonus Bonus;
    public GameObject PlayPrefab;
    public Transform PlayPrefab1;
    public PlayPref PlayPref;
    public float _speed1;
    public float CircleDiameter;

=======
    public TextMeshProUGUI HpText, DefTxt;
    public Transform PlayPrefab1;     
    float CircleDiameter = 1;
    public GameObject PanelMenu;
>>>>>>> Stashed changes
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void  Start()
    {
      //  PanelMenu.SetActive(false);
        _player = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        positions.Add(_player.position);
        HpText.text = "" + Hp; 
        _moveY = new Vector3(0f, 0f, 150f);
    }
<<<<<<< Updated upstream

    void Start()
    {       
        _moveY = new Vector3(0f, 0f, 150f);
        _hp = 1;
    }
=======
       
>>>>>>> Stashed changes

    void FixedUpdate()
    {
        _rb.AddForce(_moveY, ForceMode.Acceleration);
        Camera.position = new Vector3(Camera.position.x, 20, _player.position.z + 5);
        moveX = Input.GetAxis("Horizontal");

        //   if(Input.GetMouseButton(0))
        //   {
        //       Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * _speed * Time.deltaTime, 0, 0);
        //       transform.Translate(mouse * _speed);           
        //   }    

        _rb.velocity = new Vector3(moveX, 0, 0) * _speed;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, BorderX.x, BorderX.y), 0.5f,
            Mathf.Clamp(transform.position.z, BorderY.x, BorderY.y));

        float distance = ((Vector3)_player.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {            
            Vector3 direction = ((Vector3)_player.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }

        HpText.text = "" + Hp;
        if(Hp <= 0)
        {
            DefTxt.text = "Defeat";
            PanelMenu.SetActive(true);
        }
        if (Hp > _hp)
        {
            while(ii < Hp)
            {
               _hp = Hp; 
               ii++;
               AddCircle();                    
            }
        }

        if(Hp < _hp)
        {
            int s = _hp - Hp;
            for (int v = 0; v < s; v++) RemoveCircle();
            _hp = Hp;
            ii = Hp;
        }                   
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(PlayPrefab1, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            Hp += collision.gameObject.GetComponent<Bonus>().Hp;
        }
     
        if (collision.gameObject.CompareTag("Let"))
        {
            Hp -= collision.gameObject.GetComponent<Let>().Hp;
        }
    }
}
