﻿/*********************************************
 * 
 * 脚本名：Main_CardUnit.cs
 * 创建时间：2023/03/14 15:07:31
 *********************************************/
using Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    public partial class Main_CardUnit : UnitBase
    {
        public CardData Data { private set; get; }

        public override void OnInit()
        {
            
        }

        public void FnShow(CardData data)
        {
            Data = data;
            Img_Card.sprite = data.GetTbSuitCard().GetSpCard(LoadHelper);
        }
    }
}