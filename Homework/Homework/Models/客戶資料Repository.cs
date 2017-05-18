using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PagedList;

namespace Homework.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => !p.刪除).Include(客 => 客.客戶類別);
            
        }

        public IQueryable<客戶資料> All(bool showAll)
        {
            //注意base 與 this的寫法
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public IQueryable<客戶資料> GetIndexListByKeywordAndType(string strKeyword="",int intTypeID=0)
        {
            if (strKeyword.Length > 0 && intTypeID > 0)
            {
                return GetCustomerByActive().Where(p => (p.客戶名稱.Contains(strKeyword) | p.電話.Contains(strKeyword)) & p.客戶類別ID == intTypeID);
            }
            else if (strKeyword.Length == 0 && intTypeID > 0)
            {
                return GetCustomerByActive().Where(p => p.客戶類別ID == intTypeID);
            }
            else if (strKeyword.Length > 0 && intTypeID == 0)
            {
                return GetCustomerByActive().Where(p => (p.客戶名稱.Contains(strKeyword) | p.電話.Contains(strKeyword)));
            }
            else
            {
                return GetCustomerByActive();
            }
              
        }

        public 客戶資料 GetByID(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶資料 customer)
        {
            this.UnitOfWork.Context.Entry(customer).State = EntityState.Modified;
        }

        public IQueryable<客戶資料> GetCustomerByActive(bool Del = false, bool showAll = false)
        {
            //以下為老師寫法
            //IQueryable<客戶資料> all = this.All();
            //if (showAll)
            //{
            //    all = base.All();
            //}
            //return all.Aggregate.Where(p => p.刪除.HasValue && p.刪除.Value == Del)
            //    .OrderByDescending(p => p.ProductId).Take(10);

            //這是我的寫法
            //ToList();
            return All(showAll: showAll).Where(p => p.刪除 == Del).OrderByDescending(p => p.Id);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.刪除 = true;
            //base.Delete(entity);
        }

    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}