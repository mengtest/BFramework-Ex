﻿/*********************************************
 * BFramework
 * Module管理器
 * 创建时间：2023/09/07 14:58:23
 *********************************************/
using GameData;
using LitJson;
using MainPackage;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Framework
{
    /// <summary>
    /// Module管理器
    /// </summary>
    public class ModuleManager : ManagerBase
    {
        private Dictionary<string, ModuleBase> _allModuleDic;

        public override void OnInit()
        {
            _allModuleDic = new Dictionary<string, ModuleBase>();
        }

        public void Init(Type[] typeArr)
        {
            //初始化Module
            for (int i = 0, length = typeArr.Length; i < length; i++)
            {
                var moduleType = typeArr[i];
                var moduleBase = Activator.CreateInstance(moduleType) as ModuleBase;
                moduleBase.OnInit();
                _allModuleDic.Add( moduleType.Name, moduleBase);  
            }
        }

        /// <summary>
        /// 获取Module
        /// </summary>
        public T GetModule<T>() where T : ModuleBase
        {
            Type type = typeof(T);
            if (!_allModuleDic.ContainsKey(type.Name))
            {
                GameGod.Instance.Log(E_Log.Error, type.Name, "未进行初始化！");
                return null;
            }
            return _allModuleDic[type.Name] as T;
        }

        public override void OnUpdate() { }
        public override void OnDispose() 
        {
            foreach (var item in _allModuleDic)
            {
                item.Value.OnDispose();
            }
            _allModuleDic.Clear();
            _allModuleDic = null;
        }
    }
}
