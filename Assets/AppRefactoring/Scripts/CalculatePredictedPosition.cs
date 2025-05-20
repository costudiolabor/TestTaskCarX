using UnityEngine;

public class CalculatePredictedPosition {
    public Vector3 GetPredictedPosition(Vector3 shooterPos, Vector3 targetPos, Vector3 targetVelocity, float projectileSpeed, float leadDistanceMultiplier) {
        Vector3 predictedPos = targetPos;
        float distance = Vector3.Distance(shooterPos, predictedPos);
        float timeToTarget = distance / projectileSpeed;
        predictedPos = targetPos + targetVelocity * timeToTarget * leadDistanceMultiplier;
        return predictedPos;
    }
}