using UnityEngine;
using UnityEngine.AI;

namespace LP.FDG.UnitHandler
{
    public class UnitHandler : MonoBehaviour
    {

        //public UnitScriptableObject unitData;
        [SerializeField]
        private UnitScriptableObject worker, warrior, healer;



        private void Start()
        {
            GameObject newUnit = Instantiate(worker.unitPrefab, transform.position, Quaternion.identity);
            GameObject two = Instantiate(warrior.unitPrefab, transform.position, Quaternion.identity);
            GameObject three = Instantiate(healer.unitPrefab, transform.position, Quaternion.identity);
            

        }

        



    }
}
