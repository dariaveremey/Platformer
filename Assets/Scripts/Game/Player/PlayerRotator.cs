using System;
using Cinemachine;
using UnityEngine;

namespace P3D.Game.Player
{
    public class PlayerRotator : MonoBehaviour
    {

        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private PlayerMovement _movement;

        private void Awake()
        {
            //To DO: Remove Later
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_movement.Velocity.sqrMagnitude > 0)
            {
                Quaternion targetRotation = Quaternion.Euler(0,_freeLook.m_XAxis.Value,0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
            }

        }
    }
}