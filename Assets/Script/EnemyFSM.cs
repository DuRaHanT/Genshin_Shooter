using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { None = -1, Idle = 0, Wander, Pursuit, Attack, }

public class EnemyFSM : MonoBehaviour
{
    [Header("Pursuit")]
    [SerializeField] float targetRecognitionRange = 8;
    [SerializeField] float pursuitLimitRange = 10;

    [Header("Attack")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float attackRange = 5;
    [SerializeField] float attackRate = 1;

    EnemyState enemyState = EnemyState.None;
    float lastAttackTime = 0;

    [SerializeField] GameObject Hpbar;

    Status status;
    NavMeshAgent navMeshAgent;
    Transform target;
    EnemyMemoryPool enemyMemoryPool;
    DebuffBase debuffBase;
    BuffBase buffBase;

    public void Setup(Transform target, EnemyMemoryPool enemyMemoryPool)
    {
        status = GetComponent<Status>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        this.target = target;
        this.enemyMemoryPool = enemyMemoryPool;
        debuffBase = GetComponent<DebuffBase>();
        buffBase = GetComponent<BuffBase>();

        navMeshAgent.updateRotation = false;
    }

    void Update() => debuffBase.UpdateReaction();

    void OnEnable() => ChangeState(EnemyState.Idle);

    void OnDisable()
    {
        StopCoroutine(enemyState.ToString());
        enemyState = EnemyState.None;
    }

    public void ChangeState(EnemyState newState)
    {
        if (enemyState == newState) return;

        StopCoroutine(enemyState.ToString());

        enemyState = newState;

        StartCoroutine(enemyState.ToString());
    }

    IEnumerator Idle()
    {

        StartCoroutine("AutoChangeFromIdleToWander");

        while (true)
        {
            CalculateDistanceToTargetAndSelectState();
            yield return null;
        }
    }

    IEnumerator AutoChangeFromIdleToWander()
    {
        int chageTime = Random.Range(1, 5);

        yield return new WaitForSeconds(chageTime);

        ChangeState(EnemyState.Wander);
    }

    IEnumerator Wander()
    {
        float currentTime = 0;
        float maxTime = 10;

        navMeshAgent.speed = status.WalkSpeed;

        navMeshAgent.SetDestination(CalculateWanderPosition());

        Vector3 to = new Vector3(navMeshAgent.destination.x, 0, navMeshAgent.destination.z);
        Vector3 from = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = Quaternion.LookRotation(to - from);

        while(true)
        {
            currentTime += Time.deltaTime;

            to = new Vector3(navMeshAgent.destination.x, 0, navMeshAgent.destination.z);
            from = new Vector3(transform.position.x, 0, transform.position.z);
            if((to - from).sqrMagnitude < 0.01f || currentTime >= maxTime)
            {
                ChangeState(EnemyState.Idle);
            }

            CalculateDistanceToTargetAndSelectState();

            yield return null;
        }
    }

    Vector3 CalculateWanderPosition()
    {
        float wanderRadius = 10;
        int wanderJitter = 0;
        int wanderjitterMin = 0;
        int wanderjitterMax = 360;

        Vector3 rangePosition = Vector3.zero;
        Vector3 rangeScale = Vector3.one * 100.0f;

        wanderJitter = Random.Range(wanderjitterMin, wanderjitterMax);
        Vector3 targetPosition = transform.position + SetAngle(wanderRadius, wanderJitter);

        targetPosition.x = Mathf.Clamp(targetPosition.x, rangePosition.x - rangeScale.x * 0.5f, rangePosition.x + rangeScale.x * 0.5f);
        targetPosition.y = 0.0f;
        targetPosition.z = Mathf.Clamp(targetPosition.z, rangePosition.z - rangeScale.z * 0.5f, rangePosition.z + rangeScale.z * 0.5f);

        return targetPosition;
    }

    Vector3 SetAngle(float radius, int angle)
    {
        Vector3 position = Vector3.zero;

        position.x = Mathf.Cos(angle) * radius;
        position.z = Mathf.Sin(angle) * radius;

        return position;
    }

    IEnumerator Pursuit()
    {
        while(true)
        {
            navMeshAgent.speed = status.RunSpeed;

            navMeshAgent.SetDestination(target.position);

            LookRotationToTarget();

            CalculateDistanceToTargetAndSelectState();

            yield return null;
        }
    }

    IEnumerator Attack()
    {
        navMeshAgent.ResetPath();

        while(true)
        {
            LookRotationToTarget();

            CalculateDistanceToTargetAndSelectState();

            if(Time.time - lastAttackTime > attackRate)
            {
                lastAttackTime = Time.time;

                GameObject clone = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                clone.GetComponent<EnemyProjectile>().Setup(target.position);
            }

            yield return null;
        }
    }

    void LookRotationToTarget()
    {
        Vector3 to = new Vector3(target.position.x, 0, target.position.z);
        Vector3 form = new Vector3(transform.position.x, 0, transform.position.z);

        transform.rotation = Quaternion.LookRotation(to - form);
    }

    void CalculateDistanceToTargetAndSelectState()
    {
        if (target == null) return;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= attackRange) ChangeState(EnemyState.Attack);
        else if (distance <= targetRecognitionRange) ChangeState(EnemyState.Pursuit);
        else if (distance >= pursuitLimitRange) ChangeState(EnemyState.Wander);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, navMeshAgent.destination - transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRecognitionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pursuitLimitRange);

        Gizmos.color = new Color(0.39f, 0.04f, 0.04f);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void TakeDamage(int damage)
    {

        damage = (buffBase.buffSetting.shield - damage) / buffBase.buffSetting.resistance;

        bool isDie = status.DecreaseHp(damage);

        float normalizedHP = (float)status.CurrentHP / (float)status.MaxHP;
        Hpbar.transform.localScale = new Vector3(normalizedHP, 0.1f, 0.1f);
        Hpbar.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, normalizedHP);

        Hpbar.transform.LookAt(transform.position + Camera.main.transform.forward);

        if (isDie == true) enemyMemoryPool.DeactivateEnemy(gameObject);
    }

    public void MainWeaponReaction(BulletType bullet)
    {
        switch (bullet)
        {
            case BulletType.Burn:
                debuffBase.debuffSetting.isBurn = true;
                break;
            case BulletType.Lightning:
                debuffBase.debuffSetting.isLightning = true;
                break;
            case BulletType.Freezing:
                debuffBase.debuffSetting.isFreezing = true;
                break;

        }
    }

    public void GrenadeReaction(GrenadeType grenade)
    {
        switch (grenade)
        {
            case GrenadeType.Air:
                debuffBase.debuffSetting.isAir = true;
                break;
            case GrenadeType.Water:
                debuffBase.debuffSetting.isWater = true;
                break;

        }
    }
}
