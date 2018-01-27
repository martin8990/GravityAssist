using System.Collections.Generic;
using UnityEngine;
namespace Domain
{

    public class HeightContour : MonoBehaviour
    {
        public List<SplinePoint> points = new List<SplinePoint>();

        public ParticleSystem[] psx = new ParticleSystem[3];
        public ParticleSystem.Particle[][] particlesx = new ParticleSystem.Particle[3][];

        public List<ParticleSystem> psy = new List<ParticleSystem>();
        public List<ParticleSystem.Particle[]> particlesy = new List<ParticleSystem.Particle[]>();
        public GameObject yParticlesPF;

        public float speed = 0.5f;
        
        public void Update()
        {
           
            if (points.Count>psy.Count)
            {
                var go = GameObject.Instantiate(yParticlesPF, this.transform);
                psy.Add(go.GetComponent<ParticleSystem>());
                particlesy.Add(null);
            }
            if (points.Count > 1)
            {
                SplineParticles.updateParticlesX(psx, particlesx, points, speed);
            }
            if (points.Count > 0)
            {
                SplineParticles.updateParticlesY(psy, particlesy, points, speed);
            }

        }
    }

}
