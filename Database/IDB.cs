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

    interface ICrud<T>
     {
        T Salvar (T aluno);
        void Alterar (T nome, int id);
        void Remover (int Id);
        List<T>  Listar();
        List<T> Consultar ( Func<T,bool> filter);
        T ConsultarId(int id); 

     }

      interface ICrudAluno: ICrud<TbAluno>
    {
        List<IGrouping<string, TbAluno>> AgruparPorTurma();
    }

    abstract  class RemoteDB<T> : ICrud<T>, IDB where T : class, new()
    {
       public ZzyYHTbz1sContext DB {get;}

      private DbSet<T> tableDbSet;
        
      
      public RemoteDB()
      {
        DB = new  Models.ZzyYHTbz1sContext();
        tableDbSet = DB.Set<T>(); 
      }

     public void Commit()
     {
         DB.SaveChanges();
     }

     public T Salvar (T record)
     {
         tableDbSet.Add(record);
         Commit();
         return record;
     }
     public void Alterar(T record, int id)
     {
       tableDbSet.Update(record);
       Commit();
     }

     public void Remover (int id)
     {
       T record = ConsultarId(id);
       tableDbSet.Remove(record);

       Commit();
     }
     public T ConsultarId (int id)
     {
       T record = tableDbSet.Find(id);

       return record;
     }
     public List<T> Consultar(Func<T,bool> filter)
     {
       List<T> lista = tableDbSet.Where(filter).ToList();
       return lista;
     }
     public List<T> Listar()
     {
       List<T> lista = tableDbSet.ToList();
       return lista;
     }
    
    }

    



}