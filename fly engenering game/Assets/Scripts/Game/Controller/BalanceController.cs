﻿using Assets.Scripts.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Controller
{
    public class BalanceController : MonoBehaviour
    {
        [SerializeField]
        private List<BalanceData> _levelBalance;
    }
}