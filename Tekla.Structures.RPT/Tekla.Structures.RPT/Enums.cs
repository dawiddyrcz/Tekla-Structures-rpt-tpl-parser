using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT
{
    //TODO add all enums with template editor
    //TODO tests

    public enum FillPolicy
    {
        EVEN,
        CONTINUOUS,
    }

    public enum FillDirection
    {
        HORIZONTAL,
    }

    public enum FillStartFrom
    {
        TOPLEFT,
    }

    public enum OutputPolicy
    {
        NONE,
        ODD,
        NOTON,
    }

    public enum Datatype
    {
        STRING,
        INTEGER,
        DOUBLE,
    }

    public enum Justify
    {
        RIGHT,
        LEFT,
        CENTERED,
    }

    public enum SortDirection
    {
        NONE,
        ASCENDING,
        DESCENDING,
    }

    public enum Oncombine
    {
        NONE,
        SUM,
        CLOSESUM,
    }

    public enum SortType
    {
        NONE,
        COMBINE,
        DISTINCT,
    }

    public enum TemplateType
    {
        TEXTUAL,
        GRAPHICAL,
    }
    
}
