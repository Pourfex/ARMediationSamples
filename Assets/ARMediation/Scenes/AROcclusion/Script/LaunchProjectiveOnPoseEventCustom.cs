using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Instancie une balle qui revient après 3 secondes et déclenche un effet de particules après 6 secondes.
    /// </summary>
    public class LaunchProjectileOnPoseEvent : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The PoseEvent containing the position and rotation from which to launch the projectile.")]
        PoseEventAsset m_PoseEvent;

        [SerializeField]
        [Tooltip("The projectile prefab to be instantiated.")]
        GameObject m_ProjectilePrefab;

        [SerializeField]
        [Tooltip("The speed at which the projectile will be launched.")]
        [Range(.01f, 999)]
        float m_LaunchSpeed = 25;

        [SerializeField]
        [Tooltip("Particle effect to play after 6 seconds.")]
        ParticleSystem m_HitParticles;

        private bool hasLaunched = false;

        void OnEnable()
        {
            if (m_ProjectilePrefab == null || m_PoseEvent == null)
            {
                Debug.LogWarning(
                    $"{nameof(LaunchProjectileOnPoseEvent)} component on {name} has null inputs and will have no effect in this scene.", this);
                return;
            }

            m_PoseEvent.eventRaised += LaunchFromPose;
        }

        void OnDisable()
        {
            if (m_PoseEvent != null)
                m_PoseEvent.eventRaised -= LaunchFromPose;
        }

        void LaunchFromPose(object sender, Pose pose)
        {

            // Hide Canvas only the first time
            if (!hasLaunched)
            {
                GameObject canvas = GameObject.FindWithTag("Canvas");
                if (canvas != null)
                {
                    canvas.SetActive(false);
                }
                hasLaunched = true;
            }

            var projectile = Instantiate(m_ProjectilePrefab, pose.position, pose.rotation);
            var projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody == null)
            {
                projectileRigidbody = projectile.AddComponent<Rigidbody>();
            }

            // Appliquer une force initiale
            projectileRigidbody.velocity = pose.rotation * Vector3.forward * m_LaunchSpeed;

            // Démarrer le retour après 3 secondes
            StartCoroutine(ReturnProjectileAfterDelay(projectile, pose.position));

            // Lancer les particules après 6 secondes
            StartCoroutine(TriggerParticlesAfterDelay(projectile));
        }

        IEnumerator ReturnProjectileAfterDelay(GameObject projectile, Vector3 initialPosition)
        {
            yield return new WaitForSeconds(3f);

            if (projectile != null)
            {
                var projectileRigidbody = projectile.GetComponent<Rigidbody>();

                if (projectileRigidbody != null)
                {
                    Vector3 returnDirection = (initialPosition - projectile.transform.position).normalized;
                    float returnForce = m_LaunchSpeed * 0.8f; // Ajuste la force de retour

                    projectileRigidbody.velocity = returnDirection * returnForce;
                }
            }
        }

        IEnumerator TriggerParticlesAfterDelay(GameObject projectile)
        {
            yield return new WaitForSeconds(5.95f);

            if (projectile != null && m_HitParticles != null)
            {
                // Instancier les particules à l'emplacement actuel de la balle
                ParticleSystem particles = Instantiate(m_HitParticles, projectile.transform.position, Quaternion.identity);
                particles.Play();
                
                // Détruire les particules après leur durée de vie
                Destroy(particles.gameObject, particles.main.duration);
                
                // Détruire le projectile après l'effet des particules
                Destroy(projectile);
            }
        }
    }
}
