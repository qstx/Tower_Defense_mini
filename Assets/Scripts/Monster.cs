using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyTowerDefense
{
    /// <summary>
    /// ����ʵ��
    /// </summary>
    public class Monster : MonoBehaviour
    {
        public int reward;
        /// <summary>
        /// ��������
        /// </summary>
        [SerializeField]
        private MonsterTpye monsterTpye;
        public int totalHp;
        /// <summary>
        /// ���ﵱǰѪ��
        /// </summary>
        [SerializeField]
        private int curHp;
        public int CurHp { set { if (value <= 0) { curHp = 0; Die(); } else curHp = value; ShowHealth((float)CurHp / totalHp); } get { return curHp; } }
        public bool Dead { get; private set; } = false;
        public float speed = 3.5f;
        /// <summary>
        /// ����Debuff
        /// </summary>
        public float Debuff { set { navMeshAgent.speed = speed * (1 - value); } }
        /// <summary>
        /// Nav����
        /// </summary>
        [SerializeField]
        private NavMeshAgent navMeshAgent;
        [SerializeField]
        private HealthBar healthBar;
        [SerializeField]
        private Animator animator;
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        public Transform target { set { navMeshAgent.SetDestination(value.position); } }
        /// <summary>
        /// �����ܻ���
        /// </summary>
        [SerializeField]
        public Transform hitPoint;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Initial(Transform target,int totalHp,int speed)
        {
            this.target = target;
            this.totalHp = totalHp;
            this.CurHp = totalHp;
            this.speed = speed;
            Debuff = 0;
        }
        private void Die()
        {
            Dead = true;
            WaveManager.singleton.OnMonsterDead(this);
            GameManager.singleton.Money += reward;
            Destroy(navMeshAgent);
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1.5f);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                //Debug.Log("Bullet");
                CurHp = CurHp - collision.gameObject.GetComponent<Bullet>().power;
                Destroy(collision.gameObject);
            }
        }
        private void ShowHealth(float f)
        {
            healthBar.Health = f;
        }
    }
}

