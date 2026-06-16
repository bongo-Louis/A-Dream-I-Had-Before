using UnityEngine;

namespace StarterAssets
{
    [AddComponentMenu("Starter Assets/Stamina")]
    public class Stamina : MonoBehaviour
    {
        [Header("Stamina Settings")]
        [Tooltip("Maximum stamina value")]
        public float MaxStamina = 5.0f;
        [Tooltip("Stamina drained per second while sprinting")]
        public float DrainRate = 1.0f;
        [Tooltip("Stamina regenerated per second when not sprinting")]
        public float RegenRate = 0.5f;
        [Tooltip("Delay in seconds after stopping sprint before regeneration begins")]
        public float RegenDelay = 1.0f;

        public float CurrentStamina { get; private set; }

        // whether the player is currently sprinting according to stamina rules
        public bool IsSprinting { get; private set; }

        private float _regenTimer = 0f;
        private bool _requestedSprint = false;

        private void Start()
        {
            CurrentStamina = MaxStamina;
        }

        /// <summary>
        /// Inform the stamina component whether the player is requesting to sprint this frame.
        /// </summary>
        public void SetSprintRequest(bool requested)
        {
            _requestedSprint = requested;
        }

        /// <summary>
        /// Returns true if there's enough stamina to sprint.
        /// </summary>
        public bool CanSprint()
        {
            return CurrentStamina > 0f;
        }

        public void AddStamina(float amount)
        {
            CurrentStamina = Mathf.Clamp(CurrentStamina + amount, 0f, MaxStamina);
        }

        private void Update()
        {
            if (_requestedSprint && CurrentStamina > 0f)
            {
                // sprinting: drain stamina
                IsSprinting = true;
                CurrentStamina -= DrainRate * Time.deltaTime;
                if (CurrentStamina < 0f) CurrentStamina = 0f;
                _regenTimer = RegenDelay;
            }
            else
            {
                // not sprinting
                IsSprinting = false;

                if (_regenTimer > 0f)
                {
                    _regenTimer -= Time.deltaTime;
                }
                else if (CurrentStamina < MaxStamina)
                {
                    CurrentStamina += RegenRate * Time.deltaTime;
                    if (CurrentStamina > MaxStamina) CurrentStamina = MaxStamina;
                }
            }

            // clamp just in case
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
        }
    }
}
