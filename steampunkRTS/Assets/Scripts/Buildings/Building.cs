using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Building : MonoBehaviour
    {
        [SerializeField]
        private BasicBuildingSO building;

        private float health;
        private float armor;
        private float attackDmg;

        // Start is called before the first frame update
        void Start()
        {
            SetStats();
            Selections.Instance.buildingsList.Add(this.gameObject);


        }

        void OnDestroy()
        {
            Selections.Instance.buildingsList.Remove(this.gameObject);
        }

        private void SetStats()
        {
            //NavMeshAgent unitAgent = unitToSet.GetComponent<NavMeshAgent>();
            health = building.health;
            armor = building.armor;
            attackDmg = building.attack;

        }
    }
