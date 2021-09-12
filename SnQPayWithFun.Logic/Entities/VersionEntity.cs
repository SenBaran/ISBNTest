//@CodeCopy

using SnQPayWithFun.Contracts;

namespace SnQPayWithFun.Logic.Entities
{
	internal abstract partial class VersionEntity : IdentityEntity, IVersionable
	{
		public byte[] RowVersion { get; set; }
	}
}
