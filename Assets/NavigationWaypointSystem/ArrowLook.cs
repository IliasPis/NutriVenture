using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Badger
{
    public class ArrowLook : MonoBehaviour
    {
        [SerializeField]
        private Transform m_Target;
        public Transform LookAtTarget { get { return m_Target; } }

        [SerializeField]
        private Transform m_Spinner;
        public Transform Spinner { get { return m_Spinner; } }

        [SerializeField]
        private Transform m_Scaler;
        public Transform Scaler { get { return m_Scaler; } }
        public float speed;

        // Make SetTarget method public so it can be accessed from other scripts
        public void SetTarget(Transform target = null)
        {
            m_Target = target;
        }

        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (LookAtTarget)
            {
                // Calculate direction from arrow to target
                Vector3 direction = LookAtTarget.position - transform.position;

                // Calculate rotation based on the direction (ignoring camera rotation)
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

                // Apply rotation to the Scaler transform (assuming Scaler is the parent of the arrow)
                Scaler.rotation = rotation;

                // Calculate the angle between the forward direction of the arrow and the direction to the target
                float angle = Vector3.Angle(transform.forward, direction);

                // Check if the angle is greater than a certain threshold (e.g., 5 degrees) to rotate the spinner
                if (Mathf.Abs(angle) > 5f)
                {
                    // Rotate the spinner around its local Y-axis based on the walking speed
                    if (Spinner)
                    {
                        Spinner.transform.Rotate(0, speed * Time.deltaTime, 0);
                    }
                }
            }
        }

        private void OnEndMission()
        {
            SetTarget(null);
            this.gameObject.SetActive(false);
        }

        private void OnGetMisson()
        {
            // SetTarget();
            this.gameObject.SetActive(true);
        }
    }
}
