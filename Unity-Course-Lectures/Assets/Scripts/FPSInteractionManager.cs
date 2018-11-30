using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Utility;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private float _pushDistance;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _grabDistance;

    [SerializeField] private Image _target;

    private bool _pointingInteractable;
    private bool _pointingGrabbable;

    private CharacterController fpsController;
    private Vector3 rayOrigin;

    private Grabbable _grabbedObject = null;


    public float InteractionDistance
    {
        get { return _interactionDistance; }
        set { _interactionDistance = value; }
    }

    public Grabbable GrabbedObject
    {
        set { _grabbedObject = value; }
    }

    void Start()
    {
        fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        rayOrigin = _fpsCameraT.position + fpsController.radius * _fpsCameraT.forward;

        if(_grabbedObject == null)
            CheckInteraction();


        if (Input.GetMouseButtonDown(0))
        {
            if (_grabbedObject != null)
                Drop();
            else
                Push();
        }

        UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        
        Ray ray = new Ray(rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            //Check if is interactable
            Interactable interactable = hit.transform.GetComponent<Interactable>();
            _pointingInteractable = interactable != null ? true : false;
            if (_pointingInteractable)
            {
               
                if(Input.GetMouseButtonDown(1))
                    interactable.Interact(gameObject);
            }

            //Check if is grabbable
            Grabbable grabbableObject = hit.transform.GetComponent<Grabbable>();
            _pointingGrabbable = grabbableObject != null ? true : false;
            if (_pointingGrabbable && _grabbedObject == null)
            {

                if (Input.GetMouseButtonDown(1))
                {
                    grabbableObject.Grab(gameObject);
                    Grab(grabbableObject);
                }
                    
            }
        }
        else
        {
            _pointingInteractable = false;
            _pointingGrabbable = false;
        }

    }

    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _target.color = Color.green;
        else if (_pointingGrabbable)
            _target.color = Color.yellow;
        else
            _target.color = Color.red;
    }

    private void Push()
    {
        Ray ray = new Ray(rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _pushDistance))
        {
            Rigidbody otherRigidbody = hit.rigidbody;
            if (otherRigidbody != null)
            {
                otherRigidbody.AddForce(-hit.normal * _pushForce);
            }
        }
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

        _target.enabled = true;
        _grabbedObject = null;


    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);
        Vector3 grabPosition = _fpsCameraT.position + transform.forward * _grabDistance;

        _target.enabled = false;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(rayOrigin, _fpsCameraT.forward * InteractionDistance, Color.red);
    }
}
