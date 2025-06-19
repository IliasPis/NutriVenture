using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class SimpleCarController : MonoBehaviour {
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    // Threshold for considering the car's orientation as at risk of flipping
    public float flipThresholdAngle = 60f;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        if (collider.transform.childCount == 0) {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate() {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                // Calculate the angle difference between current rotation and intended rotation
                float angleDifference = Quaternion.Angle(axleInfo.leftWheel.transform.rotation, Quaternion.Euler(0f, steering, 0f));
                
                // Check if the car is at risk of flipping (angle difference exceeds threshold)
                if (angleDifference > flipThresholdAngle) {
                    // Limit the steering angle to avoid flipping
                    float limitedSteering = Mathf.Clamp(steering, -maxSteeringAngle, maxSteeringAngle);
                    axleInfo.leftWheel.steerAngle = limitedSteering;
                    axleInfo.rightWheel.steerAngle = limitedSteering;
                } else {
                    // Allow full steering if not at risk of flipping
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}
