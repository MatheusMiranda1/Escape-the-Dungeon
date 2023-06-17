using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float rotationSpeed = 5f;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public int lives = 3;

    private Transform player;
    private CharacterController characterController;
    private bool isChasingPlayer = false;
    private Animator zombieAnim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();
        zombieAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isChasingPlayer)
        {
            // Move the monster around (e.g., along a predefined path)
            // Implement your own movement logic here
        }
        else
        {
            // Chase the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; // Ignore vertical component for rotation
            zombieAnim.SetBool("run", true);

            // Rotate towards the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the player
            characterController.SimpleMove(transform.forward * movementSpeed);

            // Check if the monster is within attack range of the player
            if (directionToPlayer.magnitude <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                zombieAnim.SetBool("attack", false);
            }
        }

        if (lives == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the detection range of the monster
        if (!isChasingPlayer && other.CompareTag("Player"))
        {
            isChasingPlayer = true;
        }
    }

    private void AttackPlayer()
    {
        zombieAnim.SetBool("attack", true);
        lives = lives - 1;
    }
}
