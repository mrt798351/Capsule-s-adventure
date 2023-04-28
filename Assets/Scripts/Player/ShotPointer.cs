using UnityEngine;

public class ShotPointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCam;
    [SerializeField] private Transform _body;

    private float _yEuler; 

    private void LateUpdate()
    {
        Ray ray = _playerCam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;

        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if(toAim.x < 0 )
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8f);
        }
        else 
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8f);
        }
        _body.localEulerAngles = new Vector3(0, _yEuler, 0);
    }
}
