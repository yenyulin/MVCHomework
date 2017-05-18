using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homework.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => !p.刪除).Include(客 => 客.客戶資料);
        }

        public IQueryable<客戶銀行資訊> GetByKeyword(string search)
        {
            return All().Where(p => p.銀行名稱.Contains(search) | p.帳戶名稱.Contains(search) | p.銀行名稱.Contains(search));
        }

        public 客戶銀行資訊 GetByID(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶銀行資訊 customer)
        {
            this.UnitOfWork.Context.Entry(customer).State = EntityState.Modified;
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            entity.刪除 = true;
            //base.Delete(entity);
        }

    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}