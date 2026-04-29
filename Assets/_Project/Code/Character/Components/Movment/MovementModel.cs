using System;
using Project.Services;
using UnityEngine;

namespace Project.Gameplay
{
    public class MovementModel
    {
        private readonly MovmentConfig _config;
        private readonly IInputService _inputService;


        public Action jumpAction;
        public float horizontalForce { get => _horizontalForce; }
        private float _horizontalForce;

        public MovementModel(MovmentConfig config, IInputService inputService)
        {
            _config = config;
            _inputService = inputService;
        }

        public void Tick()
        {
            HandleJump();
            HandleMovement();
        }
        private void HandleJump()
        {
            if (_inputService.JumpInput)
            {
                jumpAction?.Invoke();
            }
        }

        private void HandleMovement()
        {
            _horizontalForce = _inputService.MoveInput * _config.MoveSpeed;
        }
       
    }
}
