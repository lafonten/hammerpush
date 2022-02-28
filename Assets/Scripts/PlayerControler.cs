using UnityEngine;

public enum PlayerState
{
    idle,
    run,
    attack,
    dead
}

public class PlayerControler : MonoBehaviour
{
    private PlayerState playerState;
    private Animator playerAnimator;
    private Touch touch;
    public bool CanShot=false;
    public bool CanRun = true;

    [Header("Hammer Features")] 
    public int hammerPower;

    [Header("Player Features")] 
    [SerializeField] private float _speed_coefficient_forward;
    [SerializeField] private float _speed_coefficient_swap;


    [Header("Ray Features")] 
    [SerializeField] private float ray_X;
    [SerializeField] private float ray_Y;
    [SerializeField] private float ray_Z;
    [SerializeField] private float distance_ray;

    void Start()
    {
        playerState = PlayerState.idle;
        playerAnimator = this.GetComponent<Animator>();
    }

    
    void Update()
    {
        MoveForward(SceneControler.sCon.CanStartGame,transform.forward,_speed_coefficient_forward);
        SwapControl();
        UpdateAnimation();
        ForwardObjectControl();
    }

    void SwapControl()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                this.transform.position += transform.right * touch.deltaPosition.x * Time.deltaTime * _speed_coefficient_swap;
            }
        }
    }

    void MoveForward(bool CanStartMove, Vector3 direction, float forwad_speed)
    {
        if (CanStartMove)
        {
            if (CanRun)
            {
                playerState = PlayerState.run;
                transform.position += direction * forwad_speed * Time.deltaTime;
            }
        }
    }

    void ForwardObjectControl()
    {
        RaycastHit hit;

        Vector3 rayPosition = new Vector3(transform.position.x + ray_X, transform.position.y + ray_Y,
            transform.position.z + ray_Z);

        Ray rayForward = new Ray(rayPosition, transform.forward);

        if (Physics.Raycast(rayForward,out hit,distance_ray))
        {
            if (hit.collider.gameObject.CompareTag("Small_hammer"))
            {
                LootHammer(hit.collider.gameObject);
            }


            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                CanRun = false;
                playerState = PlayerState.attack;
            }
        }
        else
        {
            CanRun = true;
        }
    }

    void LootHammer(GameObject smallHammer)
    {
        Destroy(smallHammer);
        hammerPower += 1;
    }

    void UpdateAnimation()
    {
        if (playerState == PlayerState.run)
        {
            playerAnimator.SetTrigger("run");
        }
        if (playerState == PlayerState.attack)
        {
            playerAnimator.SetTrigger("attack");
        }
    }

    void Hammer()
    {
        CanShot = true;
    }
}
