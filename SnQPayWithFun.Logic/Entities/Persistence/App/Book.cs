using CommonBase.Extensions;
using SnQPayWithFun.Contracts.Persistence.App;
using System;

namespace SnQPayWithFun.Logic.Entities.Persistence.App
{
	internal partial class Book : VersionEntity, IBook
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
