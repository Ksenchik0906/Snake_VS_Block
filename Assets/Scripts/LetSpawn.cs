using UnityEngine;
using TMPro;

public class LetSpawn : MonoBehaviour
{ 
    int _planeCount = 8;
    public int Level;
    public GameObject LetPrefab, BonusPrefab;
    public Transform PlaneScale, FinishPlatform;      
    public Material RedMaterial, SiniiMaterial;    
    public GameMeneg GM;
    public TextMeshProUGUI LevelTxt, PanelLevelTxt;
   
    void Start() 
    {
        Level = GM.Level;
        _planeCount += Level;
        LevelTxt.text = Level+1  + " Level" ;
        PanelLevelTxt.text = Level+1 + " Level";
        Debug.Log("Level = "+ Level);

        for (int b=1; b < _planeCount; b++)
        {
            PlaneScale.localScale = new Vector3(1, 1, _planeCount + 1);
            FinishPlatform.localPosition = new Vector3(0, 0.5f, 10 * _planeCount);

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
