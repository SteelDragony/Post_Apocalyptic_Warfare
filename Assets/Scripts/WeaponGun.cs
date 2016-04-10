using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WeaponGun : Weapon {
    public ParticleSystem tracers;
    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        tracers = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {

    }

    public override bool Fire(UnitHealth target)
    {
        if(base.Fire(target))
        {
            tracers.Emit(1);
            return true;
        }
        else
        {
            return false;
        }
    }

}
