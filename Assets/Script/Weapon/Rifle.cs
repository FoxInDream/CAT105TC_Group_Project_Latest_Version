using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Shoot Parameter")]
    public float interval; //FireRate
    private float shootTimer;
    public  float maxReloadTime;
    public float reloadTimer;
    public float bulletDamage;
    public int maxBulletNumber;
    public int currentbulletNumber;
    public bool isReload;
    [Header("Mouse Related Parameter")]
    private Vector2 mousePosition;
    private Vector2 direction;
    [Header("Components")]
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    private Transform muzzle;
    private Transform shellPosition;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        muzzle = transform.Find("Muzzle");
        shellPosition = transform.Find("Shell");
    }


    private void OnEnable()
    {
        currentbulletNumber = maxBulletNumber;
    }
    private void Update()
    {
        if(Time.timeScale !=0)
        Direction(); //Control the rotation direction of the gun

        Disapper();
    }

    private void FixedUpdate()
    {
        if (!Reload())
        Shoot(); //Cooldown shooting system to avoid rapid, continuous firing like a spray.
    }

    private void Direction() 
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;
        if (mousePosition.x < transform.position.x)
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), 1);
        if (mousePosition.x > transform.position.x)
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), 1);

    }
    private void Shoot()
    {
        if(shootTimer != 0)
        {
            shootTimer -= Time.deltaTime;
            if(shootTimer <= 0)
                shootTimer = 0;
        }
        if(Input.GetMouseButton(0))
        {
            if(shootTimer <= 0 && Time.timeScale != 0)
            {
                Fire();
                shootTimer = interval;
            }
        }
    }
    private void Fire()
    {
        currentbulletNumber--;
        animator.SetTrigger("Shoot");
        GameObject bullet = PoolManager.instance.Get(0);
        bullet.GetComponent<Bullet>().SetSpeed(direction);//Call the flight function of the bullet
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        bullet.transform.position= muzzle.position;
        GameObject shell= PoolManager.instance.Get(1);
        shell.transform.position = shellPosition.position;
    }

    private bool Reload() //Calculate the reload duration
    {
        if(currentbulletNumber <= 0)
        {
            isReload = true;
            reloadTimer -= Time.deltaTime;
        }
        if(reloadTimer <= 0)
        {
            reloadTimer= maxReloadTime;
            isReload = false;
            currentbulletNumber = maxBulletNumber;
        }

        return isReload;
    }

    private void Disapper() // Ensure it disappears along with the player when the player dies
    {
        if(GameManager.instance.player.currentHP<=0)
        {
            animator.SetTrigger("Disapper");
        }
    }
}
