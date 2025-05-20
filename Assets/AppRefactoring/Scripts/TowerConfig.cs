using UnityEngine;

namespace AppRefactoring.Scripts {
    [CreateAssetMenu(fileName = "NewTowerConfig", menuName = "Scriptable Objects/NewTowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        [SerializeField] private CannonTower _cannonTowerPrefab;
        [SerializeField] private SimpleTower _simpleTowerPrefab;
        public CannonTower CannonTowerPrefab => _cannonTowerPrefab;
        public SimpleTower SimpleTowerPrefab => _simpleTowerPrefab;
    }
}