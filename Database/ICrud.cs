using System;
using System.Collections.Generic;
using System.Linq;
namespace Abstra_oGen_rica.Database
{
     interface ICrud<T>
     {
        T Salvar (T aluno);
        void Alterar (T nome, int id);
        void Remover (int id);
        List<T>  Listar();
        List<T> Consultar ( Func<T,bool> filter);
        T Consultar(int id); 

     }
    interface IDB
    {
        Models.ZzyYHTbz1sContext DB{get ;}
        void Commit();

    }
}