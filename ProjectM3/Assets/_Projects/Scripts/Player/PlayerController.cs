using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Stats
    [SerializeField] private float speed;
    [SerializeField] private int _hp;
    public bool isDeath;
   
    //Direction
    private float horizontal;
    private float vertical;
    private Vector2 direction;

    public Vector2 lastDirection;

    public Vector2 Direction
    {
        get { return direction; }
    }

    //Components 
    private Rigidbody2D _rb;
    public LifeController lifePlayer;
    private AnimationHandler _anim;
 
    //Class Functions
    public void SetAndNormalize()
    {
        float lenghtVector = direction.magnitude;
        if (lenghtVector > 1)
        {

            direction/=Mathf.Sqrt(lenghtVector);

        }
    }

    public void DiePlayer()
    {
        isDeath = true;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,3f);

    }
    //Unity Messages
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0; 
        }

        _anim = GetComponentInChildren<AnimationHandler>();
        lifePlayer = GetComponent<LifeController>();
        if (lifePlayer == null)
        {
            lifePlayer = gameObject.AddComponent<LifeController>();
        }
        lifePlayer.Hp = _hp;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero&&!isDeath) 
        {         
            SetAndNormalize();
            lastDirection = direction.normalized;
            _rb.MovePosition(_rb.position + direction * speed * Time.deltaTime);
            _rb.velocity = Vector2.zero;
        }
       
    }
}
