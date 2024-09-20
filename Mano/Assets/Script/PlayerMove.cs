using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private static float speed = 75f;
    public CharacterController charController;

    public Camera camera;
    [SerializeField]private float mouseSensitivity = 50f; // sensibility

    [SerializeField] private float xRotation = -18.79f,
        yRotation = -90;
    //Max , min rotate
    [SerializeField]private float maxRotation = 0,minRotation = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Movimiento:
        Vector3 movement = transform.forward*vertical + transform.right*horizontal;
        charController.Move(movement * Time.deltaTime * speed);
        
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //las rotaciones se actualizaran;  
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);
        yRotation += mouseX;
        
        camera.transform.localRotation = Quaternion.Euler(22+xRotation,0,0);
        
        transform.Rotate(Vector3.up * mouseX*8);
        
        
    }
}
