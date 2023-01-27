using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetSpawn : MonoBehaviour
{
    public GameObject LetPrefab, BonusPrefab, Player, Camera;
    public Transform PlaneScale, FinishPlatform;
    int planeCount = 8;   
    public Material RedMaterial;
    public Material SiniiMaterial;   
   
    void Start()
    {        
        for (int b=1; b<8; b++)
        {
            PlaneScale.localScale = new Vector3(1, 1, planeCount + 1);
            FinishPlatform.localPosition = new Vector3(0, 0, 10 * planeCount);

            for (int i=0; i<5; i++)
            {
                int c = Random.Range(4, 6);
                if(c == 4)
                {
                    int d = Random.Range(0, 4);
                    if(d == i) {    }
                    else
                    {
                       int type = Random.Range(1, 7);
                       GameObject a = Instantiate(LetPrefab, new Vector3(i * 2 - 4, 0.8f, 10 * b), Quaternion.identity);
                       Let let = a.GetComponent<Let>();
                       let.Hp = type;
                       if(type <= 4) let._meshRender.material = RedMaterial;
                       if (5 <= type) let._meshRender.material = SiniiMaterial;
                    }                   
                }
                else
                {
                    int type = Random.Range(1, 7);
                    GameObject a = Instantiate(LetPrefab, new Vector3(i * 2 - 4, 0.8f, 10 * b), Quaternion.identity);
                    Let let = a.GetComponent<Let>();
                    let.Hp = type;
                    if (type <= 4) let._meshRender.material = RedMaterial;
                    if (5 <= type) let._meshRender.material = SiniiMaterial;
                }
            }

            for(int e=0; e<2; e++)
            {
                int type = Random.Range(1, 5);
                GameObject aa = Instantiate(BonusPrefab, new Vector3(e * 2, 0.8f, 10 * b - 5), Quaternion.identity);
                Bonus bonus = aa.GetComponent<Bonus>();
                bonus.Hp = type;
            }
        }        
    }
}
