using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
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
        //float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //gameObject.transform.position = Vector3.Lerp(A, B, interpolationRatio);

        //elapsedFrames = (elapsedFrames + 0.1) % (interpolationFramesCount + 0.1);
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector2 cameraMovement = rotationActionReference.action.ReadValue<Vector2>();

        Vector3 newPos = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newCam = new Vector3(0, cameraMovement.x, cameraMovement.y);

        //Quaternion playerOrientation = Quaternion.LookRotation(newPos * speed * Time.deltaTime); 

        gameObject.transform.position += newPos * speed * Time.deltaTime ;
        gameObject.transform.Rotate(newCam); 
        
    }
}
