using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Base Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _gravityMultiplier = 1f;

    [Header("Grounded")]
    [SerializeField] private Transform _checkGroundTransform;
    [SerializeField] private float _checkGroundRadius;
    [SerializeField] private LayerMask _checkGroundMask;
    
    private void Update()
   {
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       Vector3 moveVector = transform.right * horizontal + transform.forward * vertical;
       moveVector *= (_speed * Time.deltaTime);
       
       _controller.Move(moveVector);

       bool isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundMask);
       Debug.LogError($"IsGrounded {isGrounded}");
       Vector3 fallVector =Vector3.zero;
       
       if (isGrounded && Input.GetButtonDown("Jump"))
       {
           
       }
       

       float gravity = Physics.gravity.y*_gravityMultiplier;
       fallVector.y += gravity* Time.deltaTime;

       _controller.Move(fallVector);
       

   }
}
