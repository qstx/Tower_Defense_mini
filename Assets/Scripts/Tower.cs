using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    /// <summary>
    /// ȫ������������
    /// </summary>
    public enum TowerTpye { Ballista, Canon, Watch }
    public class Tower : MonoBehaviour
    {
        /// <summary>
        /// ��Χ�ӳ�
        /// </summary>
        private float rangeBuff;
        public float RangeBuff { set { rangeBuff = value; GetComponent<BoxCollider>().size = new Vector3(30, 10, 30) * (1 + rangeBuff); } }
        /// <summary>
        /// ���ټӳ�
        /// </summary>
        public float speedBuff;
        /// <summary>
        /// �˺��ӳ�
        /// </summary>
        public float powerBuff;
        /// <summary>
        /// �ӵ�������ʱ��
        /// </summary>
        [SerializeField]
        private float fireInterval = 1;
        public float FireInterval { get { return fireInterval * (1 - speedBuff); } }
        public int cost;
        /// <summary>
        /// ����������
        /// </summary>
        [SerializeField]
        protected TowerTpye towerTpye;
        /// <summary>
        /// �ڷ�Χ�еĹ���
        /// </summary>
        [SerializeField]
        protected List<Monster> nearMonsters;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            nearMonsters = new List<Monster>();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (nearMonsters.Count > 0)
            {
                Monster monster = nearMonsters[0];
                if (!monster||monster.Dead)
                    nearMonsters.Remove(monster);
                if(nearMonsters.Count>0)
                        Fire();
            }
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.name);
            if (other.tag == "Monster")
            {
                nearMonsters.Add(other.GetComponent<Monster>());
            }
        }
        protected virtual void OnTriggerExit(Collider other)
        {
            //Debug.Log(other.name);
            if (other.tag == "Monster")
            {
                nearMonsters.Remove(other.GetComponent<Monster>());
            }
        }
        public virtual void Initial()
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        public void OnMonsterDead(Monster monster)
        {
            nearMonsters.Remove(monster);
        }
        protected virtual void Fire()
        {
            
        }
    }
}

