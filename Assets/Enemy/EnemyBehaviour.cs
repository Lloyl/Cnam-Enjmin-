using JetBrains.Annotations;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    private Transform target ;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);

    
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
        //if (other.gameObject.tag == "Player_Bullet")
        {
            Destroy(gameObject);

        }
    }
}
