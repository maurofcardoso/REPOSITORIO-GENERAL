﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Area
{
    public interface IAreaQuery
    {
        bool Exists(int id, string jwt);
    }
}
