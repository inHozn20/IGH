using UnityEngine;
using UnityEngine.UI; // Image 자료형을 위해 필요

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

    public GameObject prfHpBar;
    public GameObject canvas;

    public float height = 1.7f;

    private RectTransform hpBar;
    private Image nowHpbar;

    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, int _atkSpeed)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }

    public Move sword_man;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (sword_man.attacked)
            {
                nowHp -= sword_man.atkDmg;
                Debug.Log(nowHp);
                sword_man.attacked = false;
                if (nowHp <= 0) // 적 사망
                {
                    Destroy(gameObject);
                    Destroy(hpBar.gameObject);
                }
            }
        }
    }

    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();

        if (name.Equals("Enemy1"))
        {
            SetEnemyStatus("Enemy1", 100, 10, 1);
        }

        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(
            new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;

        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
}
