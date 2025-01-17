using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionReference;
    [SerializeField]
    private InputActionReference rotationActionReference;
    [SerializeField]
    float speed = 1.0f;
    

    private Vector3 newPos;
    private Vector2 frameMovement;
    private Vector2 cameraMovement;
    

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

        gameObject.transform.position += playerOffset * speed * Time.deltaTime;
    }
}
