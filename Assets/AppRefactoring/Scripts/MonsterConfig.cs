using UnityEngine;

namespace AppRefactoring.Scripts
{
    [CreateAssetMenu(fileName = "NewMonsterConfig", menuName = "Scriptable Objects/MonsterConfig")]
    public class MonsterConfig : ScriptableObject {
        [SerializeField] private Monster monsterPrefab;
        public Monster MonsterPrefab => monsterPrefab;
    }
}