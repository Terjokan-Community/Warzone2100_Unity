using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : BaseObjekt
{
    public int MaxHealth;
    public int CurrentHealth;
    public float weight;
    public float Speet;
    public float TurnSpeed;
    public float ReloadTime;

    public bool CanShoot;
    public BaseBullet bullet;


    public BaseTankTop Top;
    public BaseTankBody Body;
    public BaseTankBottum Bottom;

    public BaseTank() { type = Type.Tank; }
        
    public virtual void Shoot(Vector3 targetPosition)
    {
        // uses the bullet out of top to schoot
    }

    public void CreateStats()
    {
        MaxHealth = Top.MaxHealth + Body.MaxHealth + Bottom.MaxHealth;
        CurrentHealth = MaxHealth;
        weight = Top.weight + Body.weight + Bottom.weight;
        Speet = Bottom.Speet - weight;
        TurnSpeed = Bottom.TurnSpeed - weight / 2;

        bullet = Top.bullet;
    }
    public void CreateStats(BaseTankTop top, BaseTankBody body, BaseTankBottum bottum)
    {
        Top = top;
        Body = body;
        Bottom = bottum;

        CreateStats();
    }

}
