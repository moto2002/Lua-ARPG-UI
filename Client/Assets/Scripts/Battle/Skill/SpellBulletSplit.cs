﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 分裂箭
/// </summary>
public class SpellBulletSplit : SpellBullet
{
    //临时对象
    private Transform temp;

    public SpellBulletSplit(Character caster) : base(caster)
    {

    }

    public override void Initialize()
    {
        //// 求2支箭之间的角度
        //int angleNum = _skillBulletCfg.SplitNum - 1;        
        //float angle = _skillBulletCfg.SplitAngle / angleNum;

        //// 求中间一支箭的目标点
        //Vector3 forwardPos = _caster.position + _caster.forward * _skillBulletCfg.FlyRange;

        //// 创建每支箭
        //for (int i = 0; i <= angleNum; i++)
        //{
        //    // 求每支箭的朝向
        //    float radius = _skillBulletCfg.FlyRange;
        //    float x = forwardPos.x + radius * Mathf.Sin((angle * i * Mathf.Deg2Rad));
        //    float z = forwardPos.z + radius * Mathf.Cos((angle * i * Mathf.Deg2Rad));
        //    Vector3 targetpos = new Vector3(x, _caster.position.y + 1f, z);
        //    Vector3 dir = (targetpos - _caster.position).normalized;

        //    // 创建一支非指向型箭
        //    SpellBulletNormal bullet = new SpellBulletNormal(_caster);
        //    bullet.SkillBasicCfg = _skillBasicCfg;
        //    bullet.SkillBulletCfg = _skillBulletCfg;
        //    bullet.target = _target;
        //    bullet.Initialize();
        //    bullet.SetDirection(dir);
        //    Battle.instance.AddSpell(_caster.GlobalID, bullet);
        //}

        //_hited = true;

        temp = new GameObject().transform;
        _target = _caster.lockedTarget;
        // 求2支箭之间的角度
        int angleNum = _skillBulletCfg.SplitNum - 1;
        float angle = _skillBulletCfg.SplitAngle / angleNum;

        temp.position = _target.transform.position;
        temp.RotateAround(_caster.position, temp.up, angle * -angleNum / 2);

        // 创建每支箭
        for (int i = 0; i <= angleNum; i++)
        {
            Vector3 dir = (temp.position - _caster.position).normalized;
            temp.RotateAround(_caster.position, temp.up, angle);

            // 创建一支非指向型箭
            SpellBulletNormal bullet = new SpellBulletNormal(_caster);
            bullet.SkillBasicCfg = _skillBasicCfg;
            bullet.SkillBulletCfg = _skillBulletCfg;
            //bullet.target = _target;
            bullet.Initialize();
            bullet.SetDirection(dir);
            SkillManager.instance.AddSpell(_caster.GlobalID, bullet);
        }
        GameObject.Destroy(temp.gameObject);
    }
}