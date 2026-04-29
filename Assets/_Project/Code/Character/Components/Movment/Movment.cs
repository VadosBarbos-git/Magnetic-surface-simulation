using Project.Services; 
using UnityEngine;   
using VContainer;


namespace Project.Gameplay
{
    public class Movment : MonoBehaviour, IComponent
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private MovmentConfig _config;
        [SerializeField] private UpdateGrounded _ground;

        private IInputService _inputService;
        private MovementModel _model;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Start()
        {
            _model = new MovementModel(_config, _inputService);
            _model.jumpAction += Jump;
        }

        public void Tick()
        {
            _model.Tick();
            Move(_model.horizontalForce);
            ControlMaxAccelerationRB();
        }
        private void Jump()
        {
            if (!_ground.isGrounded) return;
            Vector2 jump = (rb.transform.up * _config.JumpForce) / 10;
            rb.AddForce(jump, ForceMode2D.Impulse);
        }
        private void Move(float horizontalForce)
        {  
            if (_ground.isGrounded)
            {
                Vector2 velocity = rb.linearVelocity;
                Vector2 localVel = transform.InverseTransformDirection(velocity);
                float accelRate = 30;

                localVel.x = Mathf.MoveTowards(
                    localVel.x,
                    horizontalForce,
                    accelRate * Time.fixedDeltaTime
                );

                rb.linearVelocity = transform.TransformDirection(localVel);
            }
            else
            {
                rb.AddRelativeForce(Vector2.right * horizontalForce);
            }


        }
        private void ControlMaxAccelerationRB()
        {
            if (rb.linearVelocity.magnitude > _config.MaxAccelerationRB)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * _config.MaxAccelerationRB;
            }
        }


    }
}
