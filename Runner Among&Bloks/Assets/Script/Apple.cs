using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Apple : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBodyCount;
    public int bodyCount;

    private void Start()
    {
        textBodyCount.text = bodyCount.ToString();
    }
}
