using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController charController;
    public Camera camera;
    [SerializeField]private float mouseSensitivity = 1200f; // sensibility
    [SerializeField]private static float _speed = 5f;
    [SerializeField] private float xRotation = 30;
    //Max , min rotate
    [SerializeField]private float maxRotation = 360,minRotation = -360;

    
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
        charController.Move(movement * Time.deltaTime * _speed);
        
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //las rotaciones se actualizaran;  
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);
        
        //camera.transform.localRotation = Quaternion.Euler(22+xRotation,0,0);
        
        transform.Rotate(Vector3.up * mouseX*8);
        
        
    }
}