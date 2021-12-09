using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Reference to the player
    public GameObject player;

    //The movement speed of the player
    [Range(0.1f, 10f)]
    public float speed = 1.8f;

    //How far the enemy jumps
    [Range(0.1f, 10f)]
    public float jumpDistance = 1.1f;

    //Check to see if the enemy is on the ground
    public bool _isGrounded = true;
    //Distance between the ground and the enemy before it is grounded
    public float GroundDistance = 0.2f;
    //Layer mask to assign enviroment objects to the ground
    public LayerMask Ground;
    //This is the amount of damage an enemy deals to the player
    public int damageAmount = 20;
    //The max health of the enemy
    public float maxHealth = 100f;
    //The current health of the enemy
    public float health = 100f;        
    //The rigidbody of the enemy
    private Rigidbody _body;
    //The transform for the Physics.CheckSphere to be located
    private Transform _groundChecker;    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _body = GetComponent<Rigidbody>();
        //_groundChecker = transform.GetChild(0);                
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if the enemy is on the ground so it can jump again
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //The enemy will chase the player if it is close enough
        if (Vector3.Distance(player.transform.position, transform.position) < 10f)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
            RotateIntoMoveDirection();            
        }
        else
        {
            _body.angularVelocity = new Vector3(0, 0, 0);         
        }

        //The enemy will jump at the player if it is close enough
        /*if (Vector3.Distance(player.transform.position, transform.position) < jumpDistance && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(0.42f * -1.6f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        */
       
    }

    /// <summary>
    /// Points the enemy at the player
    /// </summary>
    private void RotateIntoMoveDirection()
    {        
        Quaternion currentRotation = transform.localRotation;
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.localRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 12f);
    }

    /// <summary>
    /// This method is called when the enemy collides with the object with the "Player" tag
    /// </summary>
    /// <param name="collision">A collision with the enemy</param>
    private void OnCollisionEnter(Collision collision)
    {
        _body.angularVelocity = Vector3.zero;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(damageAmount);
        }
    }

    /// <summary>
    /// The damage an enemy should take when shot
    /// </summary>
    /// <param name="amountOfDamage">The amount of damage recieved per shot</param>
    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;

        if (health <= 0)
        {            
            Die();
        }
    }   

    /// <summary>
    /// When the enemy has no health left it dies
    /// </summary>
    void Die()
    {
        if (gameObject != null)
        {           
            enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }

}
