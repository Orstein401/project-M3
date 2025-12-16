using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Stats
    [SerializeField] private float speed;
    [SerializeField] private int _hp;
   
    //Direction
    private float horizontal;
    private float vertical;
    private Vector2 direction;

    private Vector2 lastDirection;

    public Vector2 Direction
    {
        get { return lastDirection; }
    }

    //Components 
    private Rigidbody2D _rb;
    public LifeController lifePlayer;

 
    //Class Functions
    public void SetAndNormalize()
    {
        float lenghtVector = direction.magnitude;
        if (lenghtVector > 1)
        {
            direction/=lenghtVector; 
        }
    }

    public void DiePlayer()
    {
        Debug.Log("player morto");

    }
    //Unity functions
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0; 
        }


        lifePlayer = GetComponent<LifeController>();
        if (lifePlayer == null)
        {
            lifePlayer = gameObject.AddComponent<LifeController>();
        }
        lifePlayer.Hp = _hp;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero) 
        {
            SetAndNormalize();
            lastDirection = direction;
            _rb.MovePosition(_rb.position + direction * speed * Time.deltaTime);
        }
       
    }
}
