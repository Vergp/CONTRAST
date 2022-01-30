using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public ParticleSystem PsPoeira;
	public float WalkSpeedRight, WalkSpeedLeft;
    public float JumpForce;
	public bool isAlive;
    public bool lookRight;
    public Animator animator;
    [SerializeField]public Transform _GroundCast;
    public bool mirror;
    public LayerMask layerChao;

    const float radiusGroundCheck = 0.2f;

    private bool _canJump = true ;
    private bool _isWalk, _isJump, estaPulando, _canWalk;
    private float rot, _startScale;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private RaycastHit2D _hit;

    public static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
        isAlive = true;
    }

    void Update()
    {
        /* if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.03f), _GroundCast.position))
        {
            if (!_hit.transform.CompareTag("Player"))
            {
                _canJump = true;
                _canWalk = true;
                animator.SetBool("pulando", false);
            }
        }
        else _canJump = false; */

        if ((Input.GetKeyDown(KeyCode.Space)) && GroudCheck())
        {
            _canWalk = false;
            _isJump = true;
            animator.SetBool("pulando", true);
            Invoke("paraPulo", animator.GetCurrentAnimatorClipInfo(0).Length);
            createDust();
        }
    }

    void FixedUpdate()
    {
        //checa lado que o personagem esta olhando
        atualizaLado();

        if (Input.GetKey(KeyCode.X))
        {
            if (lookRight) {
                mirror = false;
                rig.velocity = new Vector2(WalkSpeedRight, rig.velocity.y);
            }
            else
            {
                mirror = true;
                rig.velocity = new Vector2(-WalkSpeedLeft, rig.velocity.y);
            }
                animator.SetFloat("velocity", 1);
                estaPulando = false;
        }

        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            animator.SetFloat("velocity", 0);
        }

        if (_isJump)
        {
            rig.AddForce(new Vector2(0, JumpForce));
            _isJump = false;
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
    }

    private void atualizaLado()
    {
        //atualiza lado que o personagem está olhando
        if (!mirror)
        {
            transform.localScale = new Vector3(_startScale, _startScale, 1);
        }
        if (mirror)
        {
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
        }
    }
    public void mudaDirecao()
    {
        if (lookRight)
        {
            lookRight = false;
            mirror = true;
        }
        else
        {
            lookRight = true;
            mirror = false;
        }
    }

    void paraPulo()
    {
        animator.SetBool("pulando", false);
    }

    public bool GroudCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_GroundCast.position, radiusGroundCheck ,layerChao);
        if (colliders.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("agua"))
        {
            isAlive = false;
        }
    }
    void createDust()
    {
        PsPoeira.Play();
    }
}
