using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    private PlayerMovements PlayerMovements;

    private Animator Animator;

    private SpriteRenderer SpriteRenderer;

private void Awake() {
    PlayerMovements = new PlayerMovements();
    Animator = GetComponent<Animator>();
    SpriteRenderer = GetComponent<SpriteRenderer>();
}
private void OnEnable() {
    PlayerMovements.Enable();
}
private void OnDisable() {
    PlayerMovements.Disable();
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      move();
    }

    private void move(){
         float movementInput = PlayerMovements.Land.Move.ReadValue<float>();

      Vector3 currentPosition = transform.position;
      currentPosition.x += movementInput * speed * Time.deltaTime;
      transform.position = currentPosition;

      if (movementInput != 0 )Animator.SetBool("Run",true);
      else Animator.SetBool("Run",false);

      if (movementInput == 1) SpriteRenderer.flipX = false;
      else if (movementInput == -1)SpriteRenderer.flipX = true;
    }
}
