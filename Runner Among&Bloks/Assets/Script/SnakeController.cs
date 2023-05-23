using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float speedForward = 5;
    [SerializeField] private float speedSide = 3;
    [SerializeField] private Joystick joystick;
    [SerializeField] private UIManager uiManager;
    [Header("Slider")]
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private Transform _finish;
    [SerializeField] private ShakeLenght shakeLenght;
    

    private void Start()
    {
        _progressSlider.maxValue = Mathf.Abs(transform.position.x - _finish.position.x);
    }
    private void SliderFill()
    {
        _progressSlider.value = _progressSlider.maxValue - Mathf.Abs(transform.position.x - _finish.position.x);
        
    }

    private void Update()
    {
        
        if (shakeLenght.canMove)
        {
            Move();

            if (uiManager._canMove)
            {
                SliderFill();
            }
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.left * speedForward * Time.deltaTime);

        if (joystick.Horizontal < 0)
        {
            transform.Translate(Vector3.back * speedSide * Time.deltaTime);
        }
        if (joystick.Horizontal > 0)
        {
            transform.Translate(Vector3.forward * speedSide * Time.deltaTime);
        }
    }


}
