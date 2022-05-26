using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    /// <summary>
    /// 全部防御塔类型
    /// </summary>
    public enum TowerTpye { Ballista, Canon, Watch }
    public class Tower : MonoBehaviour
    {
        /// <summary>
        /// 范围加成
        /// </summary>
        private float rangeBuff;
        public float RangeBuff { set { rangeBuff = value; GetComponent<BoxCollider>().size = new Vector3(30, 10, 30) * (1 + rangeBuff); } }
        /// <summary>
        /// 射速加成
        /// </summary>
        public float speedBuff;
        /// <summary>
        /// 伤害加成
        /// </summary>
        public float powerBuff;
        /// <summary>
        /// 子弹发射间隔时间
        /// </summary>
        [SerializeField]
        private float fireInterval = 1;
        public float FireInterval { get { return fireInterval * (1 - speedBuff); } }
        public int cost;
        /// <summary>
        /// 防御塔类型
        /// </summary>
        [SerializeField]
        protected TowerTpye towerTpye;
        /// <summary>
        /// 在范围中的怪物
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

