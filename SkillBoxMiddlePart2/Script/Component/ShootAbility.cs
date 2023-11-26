using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float shootDelay;

    private float _shootTime = float.MinValue;
public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;

        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position, t.rotation);
        }
        else
        {
            Debug.LogError("[Shoot Ability] No bullet prefab link!");
        }
    }
}
