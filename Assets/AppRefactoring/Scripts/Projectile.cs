using UnityEngine;

namespace AppRefactoring.Scripts {
    public class Projectile : View, ITickble {
        [SerializeField] protected float speed = 0.2f;
        [SerializeField] protected int damage = 10;
        public virtual void Tick() { }
        
        void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent(out Monster monster) == false) return;
            var health = monster.GetHealth();
            health -= damage;
            monster.SetHealth(health);
            if (health <= 0) {
                monster.Hide();
            }
            Hide();
        }
    }
}