using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_TA : MonoBehaviour
{
    // Will use the collider on the Managers object as a targeting range. Using 'OnCollision'.
    // Start is called before the first frame update
    [SerializeField] bool onGround;
    [SerializeField] float targetingRange;
    CapsuleCollider targetingCollider;
    GameObject current_target;
    public WepCore weapon; // this and turret head need to be referencing the object spawned by turret builder
    public Transform turretHead;
    public int turnspd;
    public int count_inrange = 0;
    [SerializeField] List<GameObject> hostiles = new List<GameObject>(); // make this array of enemy components containing the data needed for the agent
    void Start()
    {
        targetingCollider = GetComponent<CapsuleCollider>();
        targetingCollider.radius = targetingRange;
    }

    public void UpdateWeapons(GameObject w)
    {
        turretHead = w.transform;
        weapon = GetComponent<WepCore>();

    }

    private void OnTriggerEnter(Collider c)
    {
        //Debug.Log("Trigger Enter");

        //using on trigger because its not physical collider
        if (c.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy detected in-range");
            int new_len = count_inrange++;
            // check if full OR empty
            hostiles.Add(c.gameObject);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        //Debug.Log("Trigger Exit");

        //using on trigger because its not physical collider
        if (c.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy detected leaving range");
            count_inrange--;
            int enemyidx = hostiles.IndexOf(c.gameObject);
            hostiles.RemoveAt(enemyidx);
            
        }
    }

    private void OnTriggerStay(Collider o)
    {
        if (! o.CompareTag("Enemy"))
        {
            hostiles.Remove(o.gameObject);
        }
    }
    GameObject FindClosestHostile(){
        GameObject closest = null;
        float lowest_dist = Mathf.Infinity;
        for (int i = 0; i < hostiles.Count; i++)
        {
            GameObject o = hostiles[i];
            float dist = Vector3.Distance(o.transform.position, transform.position);
            if (dist < lowest_dist && o.CompareTag("Enemy"))
            {
                closest = o;
                lowest_dist = dist;
            }
        }



        return closest;
    }

    void CleanTargetList()
    {
        for (var i = hostiles.Count - 1; i > -1; i--)
        {
            if (hostiles[i] == null)
                hostiles.RemoveAt(i);
        }
    }

    bool CheckLOS()
    {
        Vector3 shootingfrom = weapon.ReturnActiveFP().position;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(shootingfrom, turretHead.forward, out hit, Mathf.Infinity, 3))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.DrawRay(shootingfrom, turretHead.forward * hit.distance, Color.red);
                //Debug.Log("Did Hit");
                return true;
            } else
            {
                Debug.DrawRay(shootingfrom, turretHead.forward * targetingRange, Color.white);
                //Debug.Log("Did not Hit");
                return false;
            }

        }
        else
        {
            Debug.DrawRay(shootingfrom, turretHead.forward * targetingRange, Color.white);
            //Debug.Log("Did not Hit");
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CleanTargetList();
        
        if (current_target != null && turretHead != null)
        {
            // Rotate turret head to face the target
            Vector3 targpos = current_target.transform.position;
            // adjust aim more towards chest
            targpos.y += 1;
            Vector3 lookv = targpos - turretHead.position;
            if (onGround)
                lookv.y = 0;
            var m_lookAtRotation = Quaternion.LookRotation(lookv);
           

            turretHead.rotation = Quaternion.RotateTowards(turretHead.rotation, m_lookAtRotation, turnspd * Time.deltaTime);

            //Debug.Log("Firing turret!");

            
            bool hasLOS = CheckLOS();
            if (weapon.readyToShoot && CheckLOS())
                weapon.Shoot();
        } else
        {
            //target is null, return to resting rotation and continue checking for targets
            current_target = FindClosestHostile();
        }
    }
}
