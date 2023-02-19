﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//
// globalna klasa (ne se dodava na nisto)
//

public class XpSystem
{
    private int xp, lvl, toNextLvl, money;
    public event EventHandler onLvlChange, onXpGain, onMoneyGain;

    public XpSystem()
    {
        xp = 0;
        lvl = 0;
        toNextLvl = 100;    //za nareden level (promenlivo)

        money = 0;
    }

    public void AddXp(int xp)
    {
        this.xp += xp;
        if(this.xp >= toNextLvl)
        {
            lvl++;
            this.xp -= toNextLvl;
            if (onLvlChange != null) onLvlChange(this, EventArgs.Empty);
        }
        if(onXpGain != null) onXpGain(this, EventArgs.Empty);
    }

    public void AddMoney(int money)
    {
        this.money += money;
        if(onMoneyGain != null) onMoneyGain(this, EventArgs.Empty);
    }

    public int getlvl()
    {
        return lvl;
    }

    public int getxp()
    {
        return xp;
    }

    public float getxpn()
    {
        return (float)xp/(float)toNextLvl;
    }

    public int getmoney()
    {
        return money;
    }
}
