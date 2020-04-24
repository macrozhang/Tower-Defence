using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerContribute2 : MonoBehaviour
{
    //塔属性：攻击力，血量，名字，价格，升级价格，回收价格

    public int HP;                 //血量
    public int AttackAbility;      //攻击力

    public int BuildPrice;         //建造价格
    public string TowerName;       //塔名字
    public int UpgradePrice;       //升级价格
    public int ReturnPrice;        //回收价格


    //HP;                 //血量
    public int getHP()
    {
        return HP;
    }

    public void modifyHP(int dmg)
    {
        HP += dmg;
    }

    //AttackAbility;      //攻击力
    public int getAttackAbility()
    {
        return AttackAbility;
    }

    public void modifyAttackAbility(int Temp)
    {
        AttackAbility += Temp;
    }


    private int buildPrice()         //建造价格
    {
        return BuildPrice;
    }

    private string towername()       //塔名字
    {
        return TowerName;
    }
    private int upgradeprice()       //升级价格
    {
        return UpgradePrice;
    }
    private int returnprice()        //回收价格
    {
        return ReturnPrice;
    }
}
