//@CodeCopy

using SnQPayWithFun.Contracts;

namespace SnQPayWithFun.Logic.Entities
{
	internal abstract partial class IdentityEntity : IIdentifiable
	{
		public int Id { get; set; }
	}
}
