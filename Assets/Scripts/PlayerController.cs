using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Rigidbody2D _rb;
    float horizontal;
    float vertical;

    public Animator animator;

    private Vector2 _input;
    private bool _moving;
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        GetInput();
        Animate();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // left and right movement
        vertical = Input.GetAxisRaw("Vertical");

        _input = new Vector2(horizontal, vertical);
        _input.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _input * _speed;
    }

    private void Animate()
    {
        if (_input.magnitude > 0.1f || _input.magnitude < -0.1f)
        {
            _moving = true;
        }
        else
        {
            _moving = false;
        }

        if (_moving)
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);
        }

        animator.SetBool("isMoving", _moving);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Exit")
        {
            gameObject.SetActive(false);
            gameManager.win();
        }
    }
}
