using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework.Models
{   
	public  class 客戶簡覽Repository : EFRepository<客戶簡覽>, I客戶簡覽Repository
	{

	}

	public  interface I客戶簡覽Repository : IRepository<客戶簡覽>
	{

	}
}