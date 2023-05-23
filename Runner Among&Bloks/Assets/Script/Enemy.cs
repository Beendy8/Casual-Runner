using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int minHP;
    [SerializeField] private int maxHP;
    [SerializeField] private TextMeshProUGUI textHPEnemy;
    [SerializeField] private Material[] materials;
    [SerializeField] private int for2Materials;
    [SerializeField] private int for3Materials;

    public int HP; 

    private void Start()
    {
        HP = Random.Range(minHP, maxHP);
        textHPEnemy.text = HP.ToString();
        if(HP < for2Materials)
        {
            GetComponent<MeshRenderer>().material = materials[0];
        }
        else if (HP >= for2Materials || HP < for3Materials)
        {
            GetComponent<MeshRenderer>().material = materials[1];
        }
        else
        {
            GetComponent<MeshRenderer>().material = materials[2];
        }
    }
    public void TakeDamage()
    {
        HP -= 1;
        textHPEnemy.text = HP.ToString();
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
