using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private Transform _spriteTransform;
    public GameObject playerd;
    public Transform player;
    public float speed;
    public int etat;
    public int type;
    public float tempsDommage; 
	// Update is called once per frame
    
	public void Awake()
	{
		player = FindObjectOfType<PlayerController> ().transform;
	}

	void Update () {
        
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
        if (agent.destination.x > 0) { flip(1f); }
        else { if (agent.destination.x != 0) { flip(-1f); } }

        if (etat != 0)
        {
            tempsDommage -= Time.deltaTime;
            if(tempsDommage < 0)
            {
               
                playerd.GetComponent<PlayerController>().AddDamage(1);
				AudioMgr.Instance.PlaySFX("Ghost_Attack Laugh");
				Debug.Log ("dammage done and ");
				Destroy(gameObject);
				//AudioMgr.Instance.PlaySFX("Ghost_Death");

            }
            
            if(GetComponent<Animator>().GetInteger("bad") == 0)
            {
                GetComponent<Animator>().SetInteger("bad", etat);
            }
            

        }
        if (_spriteTransform)
        {
            _spriteTransform.rotation = Quaternion.identity;
        }

    }

    public void flip(float direction)
    {
        _spriteTransform.localScale = new Vector3(Mathf.Abs(_spriteTransform.localScale.x) * direction, _spriteTransform.localScale.y, _spriteTransform.localScale.z);
    }

    public void OnClap()
    {
        if (etat == 1)//orange
        {
            Destroy(gameObject);
        }
    }

    public void OnBlow()
    {
        if (etat == 2)//red
        {
            Destroy(gameObject);
        }
    }


}
