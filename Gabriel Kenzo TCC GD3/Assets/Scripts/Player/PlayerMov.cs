using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    [Header("Speed")]
    public float moveSpeed;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;

    Vector2 _direction;

    void Update()
    {
        //Move
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.linearVelocity = _direction * moveSpeed;
        
        if(_direction != Vector2.zero)
        {
            anim.SetFloat("moveX", Mathf.Abs(_direction.x));
            anim.SetFloat("moveY", _direction.y);
        }

        GetAnimation();
        SpriteFlip();
    }
    void SpriteFlip()
    {
        if (!spriteRenderer.flipX && _direction.x < 0) spriteRenderer.flipX = true;
        else if (spriteRenderer.flipX && _direction.x > 0) spriteRenderer.flipX = false;
    }

    void GetAnimation()
    {
        if (rb.linearVelocity.magnitude != 0)
        {
            if (_direction.y > 0)
            {
                if (_direction.x == 0) anim.Play("PlayerWalkB");
                else anim.Play("PlayerWalkBS");
            }
            else if (_direction.y < 0)
            {
                if (_direction.x == 0) anim.Play("PlayerWalkF");
                else anim.Play("PlayerWalkFS");
            }
            else anim.Play("PlayerWalkS");
        }
        else anim.Play("PlayerIdle");
    }
}
