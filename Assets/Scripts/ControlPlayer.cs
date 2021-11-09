using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    private Vector3 direccion;
    private CharacterController controlador;
    public float walkingSpeed;
    public float runningSpeed;
    public bool isWalking;
    private Vector3 momentoSpeed;


    Vector3 rotation;
    public float rotationSpeed;
    public bool isRunning;

    //ANIMACIONES   

    Animator animator;

    void Start()
    {
        controlador = gameObject.GetComponent<CharacterController>();

        //ANIMACIONES   
        animator = gameObject.GetComponent<Animator>();
    }

    void Animate()
    {
        //ANIMACIONES
        animator.SetBool("caminar", isWalking);
        animator.SetFloat("speed", momentoSpeed.magnitude);
        animator.SetBool("correr", isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        

        direccion = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f) * rotationSpeed;
        isWalking = !Input.GetKey(KeyCode.LeftShift);
        isRunning = false;

        if (isWalking)
        {
            momentoSpeed = walkingSpeed * direccion;
            isRunning = false;
        }
        else
        {
            momentoSpeed = runningSpeed * direccion;
            isRunning = true;
        }
        controlador.transform.Rotate(rotation);
        controlador.SimpleMove(momentoSpeed);

        Animate();
    }
}
