using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private Transform _spriteTransform;
	[SerializeField] private NavMeshAgent _agent;

	[SerializeField] private int _playerLifePoint = 3;
	[SerializeField] private float _playerRecoveryTime = 2f;

	private bool _playerRecovery = false;


    public float invertx;
    public float inverty;
    public float vitesse;
    private float ratiovitesse;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lookDirection = Vector3.zero;
    public GameObject vision;
	public SpriteRenderer sprite;
	public Transform destination;
	

	public void Update()
	{
		ratiovitesse = (float) (vitesse/100);

		if (_characterController)
		{
			if (!_agent.enabled)
			{
	            moveDirection = new Vector3((invertx) * Input.GetAxis("Horizontal"), 0f,(inverty) * Input.GetAxis("Vertical"));
	            moveDirection *= ratiovitesse;

	            if (moveDirection.x > 0 && moveDirection.x != 0) { flip(-1); }
	            else { if (moveDirection.x != 0) { flip(1); } }

				_characterController.Move(moveDirection);

	            lookDirection = new Vector3(-1*Input.GetAxis("Horizontal2"), 0f, Input.GetAxis("Vertical2"));

	            // transform.LookAt(lookDirection);
	            if (lookDirection.x > 0 && lookDirection.z == 0) {transform.rotation= Quaternion.Euler(0f, 0f, 0f); }
	            if (lookDirection.x > 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 45, 0f); }
	            if (lookDirection.x == 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 90, 0f); }
	            if (lookDirection.x < 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 135, 0f); }
	            if (lookDirection.x < 0 && lookDirection.z == 0) { transform.rotation = Quaternion.Euler(0f, 180, 0f); }
	            if (lookDirection.x < 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 225, 0f); }
	            if (lookDirection.x == 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 270, 0f); }
	            if (lookDirection.x > 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 315, 0f); }
			}
			else
			{
				_agent.destination = destination.position;
			}
			if (_spriteTransform)
			{
				_spriteTransform.rotation = Quaternion.identity;
			}
			sprite.transform.LookAt(Camera.main.transform.position);

		
			

        }

			GameObject fogGO = GameObject.FindGameObjectWithTag("Fog");

			if (!fogGO) return;

			ParticleSystem emitter = fogGO.GetComponent<ParticleSystem>();

			if (!emitter) return;

			ParticleSystem.Particle[] particles = new ParticleSystem.Particle[emitter.maxParticles];
			emitter.GetComponent<ParticleSystem>().GetParticles(particles);

			CapsuleCollider collider = GetComponent<CapsuleCollider>();

			foreach (ParticleSystem.Particle particle in particles)
			{
				if (collider.bounds.Contains(particle.position))
				{
					AddDamage(1);
					break;
				}
			}
		}

	public void OnBlow()
	{
		GameObject fogGO = GameObject.FindGameObjectWithTag("Fog");

		if (!fogGO) return;

		ParticleSystem emitter = fogGO.GetComponent<ParticleSystem>();

		if (!emitter) return;

		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[emitter.maxParticles];
		emitter.GetComponent<ParticleSystem>().GetParticles(particles);

		SphereCollider collider = vision.GetComponent<SphereCollider>();

		List<ParticleSystem.Particle> particleList = new List<ParticleSystem.Particle>();

		foreach (ParticleSystem.Particle particle in particles)
		{
			if (!collider.bounds.Contains(particle.position))
				particleList.Add(particle);
		}

		emitter.SetParticles(particleList.ToArray(), particleList.Count);
	}

    public void flip(float direction)
    {
        _spriteTransform.localScale = new Vector3(Mathf.Abs(_spriteTransform.localScale.x)*direction, _spriteTransform.localScale.y, _spriteTransform.localScale.z);
    }

	public void AddDamage(int damage)
	{
		if (_playerRecovery || _playerLifePoint <= 0) return;

		_playerLifePoint -= damage;

		AudioMgr.Instance.PlaySFX ("Damages");

		if (_playerLifePoint <= 0)
		{
			GameMgr.Instance.GameOver();
		}
		else
		{
			_playerRecovery = true;
			StartCoroutine("PlayerRecoveryCoroutine");
		}
	}

	IEnumerator PlayerRecoveryCoroutine()
	{
		yield return new WaitForSeconds(2f);
		_playerRecovery = false;
	}
}