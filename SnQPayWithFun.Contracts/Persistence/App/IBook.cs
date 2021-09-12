using CommonBase.Attributes;
using System;

namespace SnQPayWithFun.Contracts.Persistence.App
{
	public interface IBook : IVersionable, ICopyable<IBook>
	{
		DateTime CreateDate { get; set; }
		[ContractPropertyInfo(Required = true, MaxLength = 10)]
		string ISBNNumber { get; set; }
		decimal Amount { get; set; }
		[ContractPropertyInfo(Required = false, MaxLength = 1024)]
		string Note { get; set; }
	}
}
