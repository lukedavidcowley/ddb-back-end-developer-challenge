﻿using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Rulesets.Hp
{
    public interface IHPGenerator
    {
        int GetHP(CharacterClassDetails characterClass, int constitution);
    }
}
