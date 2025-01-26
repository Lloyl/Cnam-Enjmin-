using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionReference;
    [SerializeField]
    private InputActionReference rotationActionReference;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    private Animator animator;

    private const string ANIMATOR_BOOL_IS_RUNNING = "IsRunning";

    //private int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    //private double elapsedFrames = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveActionReference.action.Enable();
        rotationActionReference.action.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 framePlayerMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector2 framePlayerRotation = rotationActionReference.action.ReadValue<Vector2>();

        Vector3 playerMovement = new Vector3(framePlayerMovement.x, 0, framePlayerMovement.y);
        Vector3 playerRotation = new Vector3(0, framePlayerRotation.x, framePlayerRotation.y);

        gameObject.transform.Rotate(playerRotation);

        Vector3 playerOffset = framePlayerMovement.x * transform.right + framePlayerMovement.y * transform.forward;
        animator.SetBool(ANIMATOR_BOOL_IS_RUNNING, framePlayerMovement.x !=0 || framePlayerMovement.y != 0);
        gameObject.transform.position += playerOffset * speed * Time.deltaTime;
    }
}
