﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic.Factories
{
    public interface IFactoryIData
    {
		IData Create(string connection);
    }
}
