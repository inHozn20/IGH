using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{

    public float speed = 2f; // 이동 속도
    private Animator animator;
    public SpriteRenderer spriteRenderer;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }

    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }

    void Start()
    {


        //data정의

        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;

        transform.position = Vector3.zero;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetAttackSpeed(1.5f);
    }

    void Update()
    {
        /**
        float h = Input.GetAxisRaw("Horizontal"); // ←: -1, →: 1

        if (h > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 오른쪽
            animator.SetBool("moving", true);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  // 왼쪽
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);
        

        if (Input.GetKeyDown(KeyCode.A) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }
        **/

        nowHpbar.fillAmount = (float)nowHp / maxHp;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1); // 오른쪽
            animator.SetBool("moving", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1); // 왼쪽
            animator.SetBool("moving", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKeyDown(KeyCode.A) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }
    }

}
