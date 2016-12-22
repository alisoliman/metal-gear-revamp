using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 200;
	public int currentHealth;
    public AudioClip deathClip;
	private GameObject character;
    public Animator anim;
	Boss boss;
	AudioSource enemyAudio;
   	CapsuleCollider capsuleCollider;
    bool isDead;
	private BossGun BossGun;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
		BossGun = GetComponentInChildren<BossGun> ();
		enemyAudio = GetComponent <AudioSource> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		character = GameObject.FindGameObjectWithTag ("BigBoss");
        currentHealth = startingHealth;
		boss = GetComponentInChildren<Boss>();

    }


    void Update ()
    {

    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		BossGun.DisableEffects ();
        capsuleCollider.isTrigger = true;
        anim.SetTrigger ("dead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
//		boss.setTarget (character.transform);
		boss.enabled = false;


    }

}
