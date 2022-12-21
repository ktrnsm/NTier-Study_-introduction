using Project.BLL.DesignPatterns.GenericRepostory.IntRep;
using Project.BLL.DesignPatterns.Singleton;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepostory.BaseRep
{
    public abstract class BaseRepository<T> : IRepostory<T> where T : BaseEntity
    {
        MyContext _db;

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }
        void Save()
        {
            _db.SaveChanges();

        }



        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
        }

        public void DeleteRange(List<T> list)
        {
            foreach(T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
            
        }

        public List<T> GetActives()
        {
            return Where(x=> x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetDatas(int number)
        {
            return _db.Set<T>().Take(number).ToList();
        }

        public List<T> GetFirstDatas( int number    )
        {
            return _db.Set<T>().OrderBy(x=> x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return _db.Set<T>().OrderBy(x=>x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where (x=>x.Status== ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where ( x=>x.Status==ENTITIES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void SetActive(T item)
        {
            item.DeletedDate=item.ModifiedDate=null;
            item.Status = ENTITIES.Enums.DataStatus.Inserted;
        }

        public void SetActiveRange(List<T> list)
        {
            foreach(T item in list)
            {
                SetActive(item);
            }
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T hastobeupdated = Find(item.ID);

            _db.Entry(hastobeupdated).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach(T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
