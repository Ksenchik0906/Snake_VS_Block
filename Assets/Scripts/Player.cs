using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    Transform _player;
    AudioSource _audio;
    Rigidbody _rb;
    Vector3 _moveY;
    float _speed = 5f;
    float Diameter = 1;
    float moveX;
    int _hp;
    int ii = 1;
    public int Hp; 
    public TextMeshProUGUI HpText, DefTxt;
    public Vector2 BorderX, BorderY;
    public Transform Camera, PlayPrefab1;    
    public GameObject PlayPrefab, PanelMenu;   
    public AudioFinish AudioFinish;
    public ParticleSystem ParSys;
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();  

    private void  Start()
    {      
       _player = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        positions.Add(_player.position);
        HpText.text = "" + Hp; 
        _moveY = new Vector3(0f, 0f, 150f);       
        _hp = 1;
        _audio = GetComponent<AudioSource>();     
    }

    void FixedUpdate()
    {
        _rb.AddForce(_moveY, ForceMode.Acceleration);
        Camera.position = new Vector3(Camera.position.x, 20, _player.position.z + 5);
        moveX = Input.GetAxis("Horizontal");     

        _rb.velocity = new Vector3(moveX, 0, 0) * _speed;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, BorderX.x, BorderX.y), 0.5f,
            Mathf.Clamp(transform.position.z, BorderY.x, BorderY.y));

        float distance = ((Vector3)_player.position - positions[0]).magnitude;

        if (distance > Diameter)
        {            
            Vector3 direction = ((Vector3)_player.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction);
            positions.RemoveAt(positions.Count - 1);
            distance -= Diameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance);
        }

        HpText.text = "" + Hp;
       
        if (Hp > _hp)
        {
            while(ii < Hp)
            {
               _hp = Hp; 
               ii++;
               AddCircle();                    
            }
        }

        if (Hp <= 0)
        {
            Time.timeScale = 0.001f;
            PanelMenu.SetActive(true);
            DefTxt.text = "Defeat";
        }
        else
        {   
            int s = _hp - Hp;
            Debug.Log("s= " + s);
            for (int v = 0; v < s; v++) RemoveCircle();         
        }            
        _hp = Hp;
        ii = Hp;                           
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
            _audio.Play();
        }
     
        if (collision.gameObject.CompareTag("Let"))
        { 
            Hp -= collision.gameObject.GetComponent<Let>().Hp;
            if(Hp <= 0)
            {
                N = 0;
                Time.timeScale = 0.001f;
                PanelMenu.SetActive(true);
                DefTxt.text = "Defeat";               
            }
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            AudioFinish.GetComponent<AudioFinish>().enabled = true;
            ParSys.Play(true);
            Invoke("Finis", 7f);
        }
    }
  
    public int Level
    {
        get => PlayerPrefs.GetInt("Level", 0);
        private set
        {
            PlayerPrefs.SetInt("Level", value);
            PlayerPrefs.Save();
        }
    }
    public int N
    {
        get => PlayerPrefs.GetInt("Level1", 0);
        set
        {
            PlayerPrefs.SetInt("Level1", value);
            PlayerPrefs.Save();
        }
    }
    void Finis()
    {
            Level++;
            N = 0;
            Time.timeScale = 0.001f;
            PanelMenu.SetActive(true);
            DefTxt.text = "Victori";
    }
}
