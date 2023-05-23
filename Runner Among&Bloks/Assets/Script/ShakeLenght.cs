using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeLenght : MonoBehaviour
{
    [SerializeField] private int Lenght;
    [SerializeField] private GameObject bodySnake;
    [SerializeField] private List<GameObject> allSnakes = new List<GameObject>();
    [SerializeField] private List<Vector3> positionHistory = new List<Vector3>();
    [SerializeField] private TextMeshProUGUI textLenght;
    [SerializeField] private TextMeshProUGUI textPoint;
    [SerializeField] private GameObject boom;
    [SerializeField] private Restart restart;
    public bool canMove;
    

    public int gap;
    public int bodySpeed;
    private float point;

    private void Start()
    {
        Lenght = 1;
        textLenght.text = Lenght.ToString();
    }
    private void Update()
    {
        positionHistory.Insert(0, transform.position);
        for (int i = 0; i < allSnakes.Count; i++)
        {
            Vector3 point = positionHistory[Mathf.Min(i * gap, positionHistory.Count - 1)];
            Vector3 moveDirection = point - allSnakes[i].transform.position;
            allSnakes[i].transform.position += moveDirection * bodySpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Lenght += other.GetComponent<Apple>().bodyCount;
            for (int i = 0; i < other.GetComponent<Apple>().bodyCount; i++)
            {
                GameObject b = Instantiate(bodySnake,new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.Euler(0, -90, 0), transform);
                allSnakes.Add(b);
            }
            textLenght.text = Lenght.ToString();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
    }
    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canMove = false;
            int count = collision.gameObject.GetComponent<Enemy>().HP;

            for (int i = 0; i < count; i++)
            {
                Instantiate(boom, new Vector3(transform.position.x + Random.Range(-1f,1), transform.position.y + Random.Range(-1f, 1), transform.position.z + Random.Range(-1f, 1)), Quaternion.identity);
                collision.gameObject.GetComponent<Enemy>().TakeDamage();
                Destroy(allSnakes[0]);
                allSnakes.RemoveAt(0);
                Lenght -= 1;
                textLenght.text = Lenght.ToString();
                point += 1;
                textPoint.text = point.ToString();
                if (Lenght <= 0)
                {
                    restart.RestartLevel();
                }
                
                yield return new WaitForSeconds(0.02f);
            }
            canMove = true;
        }
    }

}
