using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public abstract class RPTObject
    {
        public bool IsTmp { get; set; } = false;

        public abstract List<RPTObject> RPTObjects { get; set; }
        internal abstract void BindProperty(ParsedProperty property);
    }
}
