using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class FogController : MonoBehaviour
{
	#region Fields

	private ParticleSystem _emitter;

	#endregion

	public void Awake()
	{
		_emitter = GetComponent<ParticleSystem>();
	}

/*	public void OnParticleCollision(GameObject go)
	{
		if (!go.GetComponent<PlayerController>()) return;

		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[_emitter.maxParticles];
		_emitter.GetParticles(particles);

		SphereCollider collider = go.GetComponent<PlayerController>().vision.GetComponent<SphereCollider>();

		List<ParticleSystem.Particle> particleList = new List<ParticleSystem.Particle>();

		foreach (ParticleSystem.Particle particle in particles)
		{
			if (!collider.bounds.Contains(particle.position))
				particleList.Add(particle);
		}

		_emitter.SetParticles(particleList.ToArray(), particleList.Count);
	}*/
}
