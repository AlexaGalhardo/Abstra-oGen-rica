using System;
using System.Collections.Generic;
using System.Linq;
using Abstra_oGen_rica.Models;
using Microsoft.EntityFrameworkCore;

namespace Abstra_oGen_rica.Database
{
     interface IDB
    {
        Models.ZzyYHTbz1sContext DB{get ;}
        void Commit();
    }
}