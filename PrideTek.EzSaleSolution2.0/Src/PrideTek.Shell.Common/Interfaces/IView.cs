﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Common.Interfaces
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }
    }
}
