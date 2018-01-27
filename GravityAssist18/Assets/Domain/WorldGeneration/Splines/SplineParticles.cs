using System.Collections.Generic;
using UnityEngine;
namespace Domain
{
    public static class SplineParticles
    {
        public static void updateParticlesX(
            ParticleSystem[] ps, 
            ParticleSystem.Particle[][] particles,
            List<SplinePoint> splinePoints,float speed)
        {
            for (int y = 0; y < 3; y++)
            {
                if (particles[y] == null || particles[y].Length < ps[y].main.maxParticles)
                {
                    particles[y] = new ParticleSystem.Particle[ps[y].main.maxParticles];
                }
                ps[y].startLifetime = splinePoints.Count / speed;
                int nParticles = ps[y].GetParticles(particles[y]);
                for (int i = 0; i < nParticles; i++)
                {
                    var life = particles[y][i].remainingLifetime / particles[y][i].startLifetime;
                    float temp = life * (splinePoints.Count - 1);
                    var id = Mathf.FloorToInt(temp);
                    var t = temp - id;
                    var Target = SplineCalc.CalcGeneric(t, new Vector3[] { splinePoints[id].Knot_ARR[y], splinePoints[id].CTRL_OUT_x_ARR[y], splinePoints[id+1].CTRL_IN_x_ARR[y], splinePoints[id+1].Knot_ARR[y]});

                    particles[y][i].position = Target;
                }
                ps[y].SetParticles(particles[y], nParticles);
            }          
        }
        public static void updateParticlesY(
            List<ParticleSystem> ps,
            List<ParticleSystem.Particle[]> particles,
            List<SplinePoint> splinePoints, float speed)
        {
            for (int x = 0; x < splinePoints.Count; x++)
            {
                if (particles[x] == null || particles[x].Length < ps[x].main.maxParticles)
                {
                    particles[x] = new ParticleSystem.Particle[ps[x].main.maxParticles];
                }
                ps[x].startLifetime = splinePoints.Count / speed;
                int nParticles = ps[x].GetParticles(particles[x]);
                for (int i = 0; i < nParticles; i++)
                {
                    var life = particles[x][i].remainingLifetime / particles[x][i].startLifetime;
                    var Target = SplineCalc.CalcYPos(life,splinePoints[x]);

                    particles[x][i].position = Target;
                }
                ps[x].SetParticles(particles[x], nParticles);
            }
        }
    }

}
