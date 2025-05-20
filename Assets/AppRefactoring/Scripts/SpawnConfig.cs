using System;
using UnityEngine;

namespace AppRefactoring.Scripts {
    [Serializable]
    public class SpawnConfig {
        public Tower prefabTower;
        public Transform spawnPoint;
    }
}