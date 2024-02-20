using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    public float projectileFireRate;

    float timeSinceLastFire = 0;


    protected override void Start()
    {
        base.Start();


        if (projectileFireRate <= 0)
            projectileFireRate = 2.0f;

        //do any addional stuff that is need for my subclass.
    }

    private void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curPlayingClips[0].clip.name != "Fire")
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetTrigger("Fire");
                timeSinceLastFire = Time.time;
            }
        }
    }
}
