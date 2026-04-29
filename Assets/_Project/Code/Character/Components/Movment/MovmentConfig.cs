using UnityEngine;

namespace Project.Gameplay
{
    [CreateAssetMenu(fileName = nameof(MovmentConfig), menuName = "Config/ Movment")]
    public class MovmentConfig : ScriptableObject
    {


        [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;
        [field: SerializeField] public float JumpForce { get; private set; } = 4f;
        [field: SerializeField] public float Gravity { get; private set; } = 9.81f;
        [field: SerializeField] public float AngleTorque { get; private set; } = 1f;
        [field: SerializeField] public float MaxAccelerationRB { get; private set; } = 20f;
    }
}