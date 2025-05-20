using System.Collections.Generic;
using UnityEngine;

namespace AppRefactoring.Scripts {
    public class Map :MonoBehaviour {
        [SerializeField] private int _monsterCount;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private List<Transform> _cannonTowers;
        [SerializeField] private List<Transform> _simpleTowers;
        [SerializeField] private Transform _enemySpawnPoint;
        [SerializeField] private Transform _enemyDestinationPoint;
        
        public int MonsterCount => _monsterCount;
        public float SpawnInterval => _spawnInterval;
        public List<Transform> CannonTowers => _cannonTowers;
        public List<Transform> SimpleTowers => _simpleTowers;
        public Transform EnemySpawnPoint => _enemySpawnPoint;
        public Transform EnemyDestinationPoint => _enemyDestinationPoint;
        
    }
}