using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Badger
{
    public class TargetTrigger : MonoBehaviour
    {
        [SerializeField]
        private ArrowLook arrowLookScript;

        [SerializeField]
        private Transform nextTarget;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerCollider") && arrowLookScript != null && nextTarget != null)
            {
                arrowLookScript.SetTarget(nextTarget);
            }
        }
    }
}