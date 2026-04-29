
using UnityEngine;
using Project.Gameplay;

public class Gravity2D : MonoBehaviour, IComponent
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MovmentConfig _config;
    [SerializeField] private SurfaceDetector _surfaceDetector;
    [SerializeField] private float _rotationOffset = 90f;
    [Range(-1f, 1)]
    [SerializeField] private float _centerOfMassOffsetY = -0.5f;

    private void Start()
    {
        _rb.centerOfMass = new Vector2(0, _centerOfMassOffsetY);
    }
    public void Tick()
    {
        PhysicsSimulation(_surfaceDetector.GetPointForGravity());
    }
    private void PhysicsSimulation(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        _rb.AddForce(direction * _config.Gravity);
        RotateToPoint(target);
    }

    private void RotateToPoint(Vector2 targetPoint)
    {
        Vector2 dir = targetPoint - _rb.position;

        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + _rotationOffset;

        float speed = _config.AngleTorque;

        if (targetAngle > 60) speed *= 2;

        float newAngle = Mathf.LerpAngle(
            _rb.rotation,
            targetAngle,
            speed * Time.fixedDeltaTime
        );

        _rb.MoveRotation(newAngle);
    }

}
