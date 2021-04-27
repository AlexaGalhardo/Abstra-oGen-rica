using System;
using System.Collections.Generic;
using System.Linq;
using Abstra_oGen_rica.Models;

namespace Abstra_oGen_rica.Database
{
         class AlunoDatabase : RemoteDB<TbAluno>, ICrudAluno
    {
        public List<IGrouping<string, TbAluno>> AgruparPorTurma()
        {
            return DB.TbAluno.ToList().GroupBy(x=> x.NmTurma).ToList();
        }


    }
}