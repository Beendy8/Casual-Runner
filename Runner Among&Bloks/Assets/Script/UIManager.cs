using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelStart;
    public bool _canMove;
    public void TapToStart()
    {
        _panelStart.SetActive(false);
        _canMove= true;
    }
}
