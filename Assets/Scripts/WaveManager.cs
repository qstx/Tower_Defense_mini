using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public struct Wave
    {
        public int len;
        public int[] monstersNums;
        public Wave(int[] nums)
        {
            len = nums.Length;
            monstersNums=nums;
        }
    }
    public class WaveManager : MonoBehaviour
    {
        static public WaveManager singleton;
        /// <summary>
        /// ���в��εĹ���
        /// </summary>
        [SerializeField]
        private List<Wave> waveList = new List<Wave> {
            new Wave(new int[] { 6, 300, 3}),
            new Wave(new int[] { 0, 300, 3, 8, 300, 3}),
            new Wave(new int[] { 0, 300, 3, 0, 300, 3,10, 300, 3}),
            new Wave(new int[] { 6, 600, 3}),
            new Wave(new int[] { 0, 600, 3, 8, 600, 3}),
            new Wave(new int[] { 0, 600, 3, 0, 600, 3,10, 600, 3}),
            new Wave(new int[] { 0, 600, 3, 0, 600, 3, 0, 600, 3, 2,5400, 3}),
            new Wave(new int[] { 6, 900, 5}),
            new Wave(new int[] { 0, 900, 5, 8, 900, 5}),
            new Wave(new int[] { 0, 900, 5, 0, 900, 5,10, 900, 5}),
        };
        /// <summary>
        /// ��ǰ���ﲨ��
        /// </summary>
        public int CurWave { get; private set; }
        /// <summary>
        /// ��ǰ������ʣ��Ĺ���
        /// </summary>
        public List<Monster> curMonsters;
        /// <summary>
        /// �ܹ��ﲨ��
        /// </summary>
        public int WaveNums { get { return waveList.Count; } }
        /// <summary>
        /// ���������
        /// </summary>
        [SerializeField]
        private Transform bornPoint;
        [SerializeField]
        private Transform[] targetPoint;
        public bool isCurOver=true;
        public bool IsCurOver { private set { isCurOver = value; } get { return isCurOver; } }
        /// <summary>
        /// ȫ�������Ƿ�ȫ�����
        /// </summary>
        public bool isOver { get { return CurWave >= WaveNums && curMonsters.Count == 0; } }
        private void Awake()
        {
            if (!singleton)
                singleton = this;
            else
                Debug.LogError("WaveManager singleton");
        }
        // Start is called before the first frame update
        void Start()
        {
            Initial();
        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// ��ʼ��WaveManager
        /// </summary>
        private void Initial()
        {
            CurWave = 0;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void PutWave()
        {
            if(!IsCurOver)
            {
                Debug.LogError("Current Wave not Over");
                return;
            }
            if (isOver)
            {
                Debug.LogError("All Wave Over");
                return;
            }
            IsCurOver = false;
            StartCoroutine(PutOneByOne());
        }
        /// <summary>
        /// ���������򵽴��յ��ӵ�ǰ����ɾ��
        /// </summary>
        /// <param name="monster"></param>
        public void OnMonsterDead(Monster monster)
        {
            curMonsters.Remove(monster);
        }
        IEnumerator PutOneByOne()
        {
            curMonsters = new List<Monster>();
            for (int i = 0; i < waveList[CurWave].len; i=i+3)
                for (int j = 0; j < waveList[CurWave].monstersNums[i]; ++j)
                {
                    curMonsters.Add(MonsterManager.singleton.InstantiateMonster((MonsterTpye)(i/3), bornPoint, targetPoint[(int)Random.Range(0, 3)], waveList[CurWave].monstersNums[i+1], waveList[CurWave].monstersNums[i + 2]));
                    yield return new WaitForSeconds(2);
                }
            ++CurWave;
            Debug.Log(CurWave);
            if (CurWave >= 7 && CurWave <= 9)
            {
                IsCurOver = false;
                StartCoroutine(PutOneByOne());
            }
            IsCurOver = true;
        }
    }
}
