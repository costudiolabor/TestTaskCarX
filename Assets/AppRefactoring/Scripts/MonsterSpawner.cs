using System;
using System.Collections.Generic;
using UnityEngine;

namespace AppRefactoring.Scripts {
    
[Serializable]
    public class MonsterSpawner {
        private MonsterConfig _monsterConfig;
        private PoolObjects<Monster> _poolObjects;

        public MonsterSpawner(MonsterConfig monsterConfig) {
            _monsterConfig = monsterConfig;
        }
        
        public Monster[] CreateMonsters(Vector3 position, Vector3 destination, int monsterCount) {
            _poolObjects = new PoolObjects<Monster>(_monsterConfig.MonsterPrefab, monsterCount, false, null);
            return _poolObjects.GetElements();
        } 
        
        public void Spawn(Transform spawnPoint, Transform target) {
            Monster monster = _poolObjects.GetFreeElement();
            monster.transform.position = spawnPoint.position;
            monster.target = target;
            monster.ResetHealth();
            monster.Show();
        }
    }
}