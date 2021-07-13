using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 30f;
    public float boostForce = 10f;

    public Camera cam;
    private Vector3 _mousePos;
    private float _boostTimer = 0f;

    private Touch _touch;

    public static PlayerController Instance { get; private set; }

    private void Start()
    {
        Instance ??= this;
        _mousePos = transform.position;
    }

    private void FixedUpdate()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.y = transform.position.y;
        }
        #endif
        #if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(_touch.fingerId))
            {
                return;
            }

            if (_touch.phase == TouchPhase.Moved)
            {
                speed = 30;
                _mousePos = cam.ScreenToWorldPoint(_touch.position);
                _mousePos.y = transform.position.y;
            }
        }
        #endif
        rb.MovePosition(transform.position + (_mousePos - transform.position).normalized * (speed * Time.deltaTime));
    }

    public void Boost()
    {
        // _boostTimer = 2f;
        // if (transform.position.y < 0)
        // {
        //     float step = boostForce * Time.deltaTime;
        //     transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
        // }
        speed = 0;
    }
}
