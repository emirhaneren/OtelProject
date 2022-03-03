using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtelProject.Repositories
{
    //class public olmalı,T parametresi almalı, classın tüm özelliklerini kullanabilmeli, new() edilebilmeli
    public class Repository<T> where T : class, new()
    {
        DbOtelEntities db = new DbOtelEntities();

        //Metod Tanımları
        //Listeleme Metodu
        public List<T> GetAll()
        {
            //T bir tablo olacak, Listeleme metodu
            return db.Set<T>().ToList();
        }

        //Ekleme Metodu
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        //silme Metodu
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        //Bulma Metodu
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        //Kaydetme Metodu
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }

        //Bulma Metodu, Linq expression, where şart
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        //Şartlı Listeleme
        public List<T> GetListById(Expression<Func<T,bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }
    }
}

