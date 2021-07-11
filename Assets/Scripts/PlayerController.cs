using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 30f;

    public Camera cam;
    private Vector3 _mousePos;

    public static PlayerController Instance { get; private set; }

    private void Start()
    {
        Instance ??= this;
        _mousePos = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.y = transform.position.y;
        }
        rb.MovePosition(transform.position + (_mousePos - transform.position).normalized * (speed * Time.deltaTime));
    }
}
