using UnityEngine;

public class BulletContactManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
           
    }
}
