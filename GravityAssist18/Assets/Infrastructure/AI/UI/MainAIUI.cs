using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Infrastructure
{
    [RequireComponent(typeof(UnitMover))]
    [RequireComponent(typeof(UnitSelector))]

    public class MainAIUI : MonoBehaviour
    {
        public List<AIUnit> selected = new List<AIUnit>();
        UnitMover unitMover;
        UnitSelector unitSelector;
        private void Awake()
        {
            unitMover = GetComponent<UnitMover>();
            unitSelector = GetComponent<UnitSelector>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                unitSelector.OnFirstClick();    
            }
            if (Input.GetMouseButtonUp(1))
            {
                selected = unitSelector.OnUp();
            }
        }
    }

}


