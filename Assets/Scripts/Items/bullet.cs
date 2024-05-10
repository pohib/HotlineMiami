using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    
    private void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyOptions>()) 
        {
            Debug.Log("�� ������ �����");
            Destroy(gameObject);
        }
        if (collision.tag == "other")
        {
            Debug.Log("����� �� � ����� �������");
            Destroy(gameObject);
        }

    }
}
