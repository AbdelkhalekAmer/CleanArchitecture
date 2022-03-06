
using CleanArchitecture.Common;

namespace CleanArchitecture.Infrastructure;

internal class MachineDateTime : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}
