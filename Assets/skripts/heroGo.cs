using UnityEngine;
using System.Collections;

public class heroGo : MonoBehaviour
{
    public float speed = 5f;

    [Header("Footsteps")]
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private float footstepInterval = 0.4f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private AudioSource audioSource;
    private bool isWalking = false;
    private float footstepTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Если нет AudioSource — добавим
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }

        // Проверка: идёт ли персонаж
        isWalking = moveInput.magnitude > 0.1f;

        // Шаги по таймеру
        if (isWalking)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                PlayFootstep();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * speed;

        if (animator != null)
        {
            animator.SetBool("isRun", moveInput.magnitude > 0.1f);
        }
    }

    private void PlayFootstep()
    {
        if (footstepSound != null && audioSource != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f); // небольшое разнообразие
            audioSource.PlayOneShot(footstepSound);
        }
    }
}