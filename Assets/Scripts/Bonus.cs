using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public int Hp;
    public TextMeshProUGUI HpText;
      
    void Start()
    {
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
