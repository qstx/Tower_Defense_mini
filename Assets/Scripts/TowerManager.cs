using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class TowerManager : MonoBehaviour
    {
        static public TowerManager singleton;
        [SerializeField]
        public GameObject[] TowerPrefabs;
        /// <summary>
        /// ����������
        /// </summary>
        [SerializeField]
        private List<Tower> towersInScene;
        private void Awake()
        {
            if (!singleton)
                singleton = this;
            else
                Debug.LogError("TowerManager singleton");
        }
        // Start is called before the first frame update
        void Start()
        {
            towersInScene = new List<Tower>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// ��ָ�����͵��������ض�λ��
        /// </summary>
        /// <param name="towerTpye"></param>
        /// <param name="transform"></param>
        public void PutTower(TowerTpye towerTpye, Transform transform)
        {
            Tower newTower = Instantiate(TowerPrefabs[(int)towerTpye], transform).GetComponent<Tower>();
        }
        
    }

}
