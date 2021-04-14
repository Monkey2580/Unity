using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;

    private PlayerMovements PlayerMovements;

    [SerializeField]
    private string sceneName;

    SceneSwitch sceneSwitch;
    
    private void Awake() {
        PlayerMovements = new PlayerMovements();
    }
    private void OnEnable() {
        PlayerMovements.Enable();
    }
    private void OnDisable() {
        PlayerMovements.Disable();
    }

    private void Start(){
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if(playerDetected == true){
            if(kb.eKey.wasPressedThisFrame){
                sceneSwitch.SwitchScene(sceneName);
            }
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height,1));
    }
}
