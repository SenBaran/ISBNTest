//@CodeCopy

namespace SnQPayWithFun.Contracts
{
	public partial interface IVersionable : IIdentifiable
	{
		byte[] RowVersion { get; }
	}
}
