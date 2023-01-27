using UnityEngine;
using TMPro;

public class Let : MonoBehaviour
{
    public int Hp;
    public TextMeshProUGUI HpText;
    public Renderer _meshRender;
    Rigidbody _rb;

    void Start()
    {
        _meshRender = GetComponent<Renderer>();
        _rb = GetComponent<Rigidbody>();
        HpText.text = "" + Hp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);        
        }
    }
}
