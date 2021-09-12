using CommonBase.Extensions;
using SnQPayWithFun.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQPayWithFun.AspMvc.Models.Book
{
    public class Book : VersionModel, IBook
    {
		public DateTime CreateDate { get; set; }
		public string ISBNNumber { get; set; }
		public decimal Amount { get; set; }
		public string Note { get; set; }

		public void CopyProperties(IBook other)
		{
			other.CheckArgument(nameof(other));

			Id = other.Id;
			RowVersion = other.RowVersion;
			CreateDate = other.CreateDate;
			ISBNNumber = other.ISBNNumber;
			Amount = other.Amount;
			Note = other.Note;
		}
	}
}
