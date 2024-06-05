using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 100f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
