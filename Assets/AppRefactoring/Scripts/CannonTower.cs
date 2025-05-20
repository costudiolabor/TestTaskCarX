using UnityEngine;

namespace AppRefactoring.Scripts {
    public class CannonTower : Tower {
        [SerializeField] private float rotationSpeed = 5.0f;
        [SerializeField] private float projectileSpeed = 100.0f;
        [SerializeField] private float leadDistanceMultiplier = 1.1f;
        [SerializeField] private CannonProjectile prefabProjectile;
        [SerializeField] private Transform cannon;

        private PoolObjects<CannonProjectile> _poolObjects;
        private RotateTowardsTarget _rotateTowardsTarget;

        public override void Initialize() {
            _poolObjects = new PoolObjects<CannonProjectile>(prefabProjectile, maxProjectile, false, null);
            _tickble = new ITickble[maxProjectile];
            _tickble = _poolObjects.GetElements() as ITickble[];
            _rotateTowardsTarget = new RotateTowardsTarget();
        }
        public override void Tick () {
            _rotateTowardsTarget.Turn( _target,  shootPoint, cannon, projectileSpeed, leadDistanceMultiplier, rotationSpeed);
            FindTarget();
            UpdateShoot();
            TickProjectiles();
        }
        
        public override void Shoot(Monster monster) {
            if (monster.gameObject.activeInHierarchy == false) return;
            CannonProjectile projectile = _poolObjects.GetFreeElement();
            Transform projectileTransform = projectile.transform;
            projectileTransform.parent = shootPoint;
            projectileTransform.localPosition = Vector3.zero;
            projectileTransform.localRotation = shootPoint.localRotation;
            projectileTransform.parent = null;
            Transform temp = projectile.transform;
            temp.position = projectileTransform.position;
            temp.rotation = projectileTransform.rotation;
            Vector3 direction = temp.forward;
            projectile.Shoot(direction);
        }
    }
}