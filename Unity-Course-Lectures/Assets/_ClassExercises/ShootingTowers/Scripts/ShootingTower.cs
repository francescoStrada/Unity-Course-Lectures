using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    [SerializeField] private Transform _rotatingBase;
    [SerializeField] private Transform _gunPivot;
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _targetFoundRotationSpeed;
    [SerializeField] private float _maxTargetDistance;
    [SerializeField] private LayerMask _visibilityRaLayerMask;
    [Range(0,360)]
    [SerializeField] private float _viewAngle;

    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private float _shootForce;

    private Target _target;
    private bool _targetInSight = false;
    private bool _isShooting = false;

    void Start()
    {
        _target = FindObjectOfType<Target>();
        _rotatingBase.Rotate(Vector3.up, Random.Range(0f,355f));
    }

    void Update()
    {
        // Constantly Rotate Tower if Target is NOT in Sight
        if(!_targetInSight)
            _rotatingBase.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

        //Check if Target is visible to the tower
        Vector3 directionToTarget = _target.transform.position - transform.position;
        if (IsTargetVisible(directionToTarget))
        {
            //Target is visible
            _targetInSight = true;
            //Point Tower towards the target
            PointTarget(directionToTarget);
            
            //Start Shooting, if already started Shooting don't invoke again
            if(!_isShooting)
                InvokeRepeating("Shoot", 0f, _shootFrequency);

            return;
        }

        //Target is NOT visible to the tower
        CancelInvoke("Shoot");
        _isShooting = false;
        _targetInSight = false;
    }

    private void Shoot()
    {
        _isShooting = true;
        Vector3 targetHead = _target.transform.position + Vector3.up * 4f;
        Vector3 shootingDirection = (targetHead - _gunPivot.position).normalized;
        Bullet bullet = Instantiate(_bullet, _gunPivot.position, Quaternion.identity);
        bullet.transform.up = shootingDirection;

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootingDirection * _shootForce, ForceMode.Impulse);
    }

    private bool IsTargetVisible(Vector3 directionToTarget)
    {
        //CHECK IF IS WITHIN VIEW DISTANCE
        float squareTargetDistance = (directionToTarget).sqrMagnitude;
        if (squareTargetDistance <= _maxTargetDistance * _maxTargetDistance)
        {
            //CHECK IF FALLS WITHIN VIEW ANGLE
            float angleToTarget = Vector3.Angle(_rotatingBase.forward, directionToTarget.normalized);
            if (angleToTarget < _viewAngle * 0.5f)
            {
                //CHECK IF THERE ARE NO OBSTACLES
                RaycastHit hitInfo;
                Ray ray = new Ray(_rayOrigin.position, (_target.HeadPosition.transform.position - _rayOrigin.position).normalized);
                Debug.DrawRay(_rayOrigin.position, (_target.HeadPosition.transform.position - _rayOrigin.position).normalized * _maxTargetDistance, Color.cyan);

                if (Physics.Raycast(ray, out hitInfo, _maxTargetDistance, _visibilityRaLayerMask))
                {
                    Target target = hitInfo.transform.GetComponentInParent<Target>();
                    if(target)
                        return true;
                }
            }
        }

        return false;
    }

    private void PointTarget(Vector3 directionToTarget)
    {
        directionToTarget.y = 0f;
        directionToTarget.Normalize();

        Vector3 newDir = Vector3.RotateTowards(_rotatingBase.forward, directionToTarget, _targetFoundRotationSpeed * Time.deltaTime, 0f);
        _rotatingBase.rotation = Quaternion.LookRotation(newDir);
    }
}
