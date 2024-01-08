using System.Collections.Generic;
using NTierDemo.BusinessLogic;

namespace NTierDemo.BusinessLogic;
public interface IScreenBuilder
{
    List<Active> Actives { get; set; }
}
