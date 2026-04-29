
using UnityEngine;

public class SurfaceDetector : MonoBehaviour
{
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private CompositeCollider2D _colliderPlatform;
    [SerializeField] private LayerMask _layerColliderPlatform;
    [SerializeField] private float _rayOffset = 0.5f;
    [SerializeField] private float _distanceRay = 1000;
    private Vector3 _result;
    public Vector3 GetPointForGravity()
    {
        Vector3 closestPoint = _colliderPlatform.ClosestPoint(_centerPoint.position);
        Vector2 origin = _centerPoint.position;
        Vector2 dir = (closestPoint - _centerPoint.position).normalized;

        Vector2 perp = new Vector2(-dir.y, dir.x);


        Vector2 startRay0 = origin + perp * _rayOffset;
        RaycastHit2D hit2D0 = Physics2D.Raycast(startRay0, dir, _distanceRay, _layerColliderPlatform);

        Debug.DrawRay(startRay0, dir * 10f, Color.green);

        Vector2 startRay1 = origin - perp * _rayOffset;
        RaycastHit2D hit2D1 = Physics2D.Raycast(startRay1, dir, _distanceRay, _layerColliderPlatform);

        Debug.DrawRay(startRay1, dir * 10f, Color.green);

        if (hit2D0.collider == null || hit2D1.collider == null)
        {
            Debug.DrawRay(_centerPoint.position, closestPoint - _centerPoint.position, Color.red);
            _result = closestPoint;
            return closestPoint;
        }

        Vector3 result = Vector2.Lerp(hit2D0.point, hit2D1.point, 0.5f);

        Debug.DrawRay(_centerPoint.position, result - _centerPoint.position, Color.red);
        _result = result;
        return result;
    }
    private void OnDrawGizmos()
    {
        if (_colliderPlatform == null) return;

        Gizmos.color = Color.red;
        GetPointForGravity();
        Gizmos.DrawWireSphere(_result, 0.4f);
    }
}
