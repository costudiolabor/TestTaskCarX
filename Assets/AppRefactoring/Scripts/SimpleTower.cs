using UnityEngine;

namespace AppRefactoring.Scripts {
    public class SimpleTower : Tower {
        [SerializeField] private GuidedProjectile prefabProjectile;
        private PoolObjects<GuidedProjectile> _poolObjects;
        public override void Initialize() {
            _poolObjects = new PoolObjects<GuidedProjectile>(prefabProjectile, maxProjectile, false, null);
            _tickble = new ITickble[maxProjectile];
            GuidedProjectile[] projectiles = _poolObjects.GetElements();
            InitializeProjectiles(projectiles);
            _tickble = projectiles as ITickble[];
        }

        private void InitializeProjectiles(GuidedProjectile[] projectiles) {
            for (int i = 0; i  < projectiles.Length; i ++) {
                projectiles[i].Initialize();
            }
        }
        
        public override void Tick () {
            FindTarget();
            UpdateShoot();
            TickProjectiles();
        }
        public override void Shoot(Monster monster) {
            if (monster.gameObject.activeInHierarchy == false) return;
            var projectile = _poolObjects.GetFreeElement();
            projectile.transform.position = shootPoint.position;
            projectile.SetTarget(monster.transform);
        }
    }
}