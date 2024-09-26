using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController charController;
    public Camera camera;
    [SerializeField] private float mouseSensitivity = 10f; // sensibility
    [SerializeField] private static float _speed = 8f;
    [SerializeField] private float xRotation = 28f;
    //Max , min rotate
    [SerializeField] private float maxRotation = 150f, minRotation = 28f;
    private Vector3 _movePlayer; // guardamos el input del jugador el control - Incorporara
    // Ahora la parte de la gravedad: 
    public float gravity = -9.81f;
    private float verticalVelocity = 0f; // Velocidad vertical acumulada

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
        _movePlayer = transform.forward*vertical + transform.right*horizontal;
        _movePlayer = Vector3.ClampMagnitude(_movePlayer,1)*_speed;
        verticalVelocity += gravity * Time.deltaTime;
        _movePlayer.y = verticalVelocity;
        charController.Move(_movePlayer * Time.deltaTime);
        cameraMovement();
    }

    void cameraMovement()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //las rotaciones se actualizaran;  
        transform.Rotate(Vector3.up * mouseX*12);
        
        xRotation -= mouseY*5;
        Console.Out.WriteLine(xRotation);
        xRotation = Mathf.Clamp(xRotation, -10, 30);
        camera.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        
    }
    
}