using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class ShootProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject projectile;
    public float launchVelocity = 700f;
    [SerializeField]
    private InputActionReference shootActionReference;
    [Range(0.01f, 10f)]
    public float rateOfFire;
    void Start()
    {
        shootActionReference.action.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (shootActionReference.action.IsPressed())
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        Destroy(bullet, 1.0f);

    }
}

