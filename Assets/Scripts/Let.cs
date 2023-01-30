using UnityEngine;
using TMPro;

public class Let : MonoBehaviour
{
    public int Hp;
    public TextMeshProUGUI HpText;
    public Renderer _meshRender;
    Collider _col;
    MeshRenderer _mesh;  
    AudioSource _audio;

    void Start()
    {
        _meshRender = GetComponent<Renderer>();     
        HpText.text = "" + Hp;
        _audio = GetComponent<AudioSource>();
        _col = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _col.GetComponent<Collider>().enabled = false;
            _mesh.GetComponent<MeshRenderer>().enabled = false;
            _audio.Play();
            Destroy(gameObject, 1);        
        }
    }
}
