using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MyTowerDefense
{
    public class Platform : MonoBehaviour
    {
        /// <summary>
        /// 放置在此区域的塔
        /// </summary>
        public Tower tower;
        public GameObject UIPrefab;
        public GameObject UI;
        public Buff buff;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void ShowUI()
        {
            UI = Instantiate(UIPrefab, transform);
            //UI.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnClearBtnClicked(); });
        }
    }
}

