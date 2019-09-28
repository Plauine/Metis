using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    private Vector3 _rotationMask = new Vector3(0, 1, 0);

    private readonly float _rotationSpeed = 100f;
    private Vector3 _targetPointWS;

    [SerializeField] private Transform _character;

    private void OnEnable()
    {
        _targetPointWS = _character.position + new Vector3(0f, 0f, ThirdPersonCamera.dstFromTarget);
    }

    private void Update()
    {
        transform.LookAt(_character);
        transform.RotateAround(_character.transform.position, _rotationMask, _rotationSpeed * Time.deltaTime);

        if (transform.position.x == _targetPointWS.x && transform.position.z == _targetPointWS.z)
            enabled = false;
    }
}
