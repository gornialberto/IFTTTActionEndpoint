﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public interface IIFTTTActionService
    {
        void Add(IFTTTActionData item);
    }
}