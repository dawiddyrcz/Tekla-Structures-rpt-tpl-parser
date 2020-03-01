using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public abstract class RPTObject
    {
        public abstract List<RPTObject> RPTObjects { get; set; }
    }
}
