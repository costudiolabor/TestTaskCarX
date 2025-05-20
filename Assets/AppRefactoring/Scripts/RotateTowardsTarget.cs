using UnityEngine;

namespace AppRefactoring.Scripts {
    public class RotateTowardsTarget {
        private CalculatePredictedPosition _calculatePredictedPosition = new CalculatePredictedPosition();
        public void Turn(Monster target, Transform shootPoint, Transform parent, float projectileSpeed, float leadDistanceMultiplier, float rotationSpeed) {
            if (target == null) return;
            Vector3 targetVelocity = target.GetVelocity();
            Vector3 predictedPosition = _calculatePredictedPosition.GetPredictedPosition(shootPoint.position,
                target.transform.position, targetVelocity, projectileSpeed, leadDistanceMultiplier);
            Vector3 targetPosition = new Vector3(predictedPosition.x, predictedPosition.y, predictedPosition.z);
            Vector3 direction = targetPosition - parent.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            parent.rotation = Quaternion.Slerp(parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}