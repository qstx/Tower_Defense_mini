using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyTowerDefense
{
    /// <summary>
    /// ��ǰ���й��������
    /// </summary>
    public enum MonsterTpye { A, B, C, D }
    public class MonsterManager : MonoBehaviour
    {
        static public MonsterManager singleton;
        /// <summary>
        /// ��ǰ���й����Ԥ����
        /// </summary>
        public GameObject[] monsterPrefabs;
        private void Awake()
        {
            if (!singleton)
                singleton = this;
            else
                Debug.LogError("MonsterManager singleton");
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        /// <summary>
        /// ���ض�λ������ָ�����͹���
        /// </summary>
        /// <param name="type"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public Monster InstantiateMonster(MonsterTpye type, Transform origin, Transform target, int totalHp, int speed)
        {
            Monster monster = Instantiate(monsterPrefabs[(int)type], origin).GetComponent<Monster>();
            monster.Initial(target, totalHp, speed);
            return monster;
        }
    }
}

