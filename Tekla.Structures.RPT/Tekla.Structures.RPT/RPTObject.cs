using System;
using System.Collections.Generic;
using System.Linq;

namespace Tekla.Structures.RPT
{
    public abstract class RPTObject
    {
        public bool IsTmp { get; set; } = false;

        public List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal void BindProperty(ParsedProperty parsedProperty)
        {
            try
            {
                var type = this.GetType();
                var properties = type.GetProperties().
                    Where(p => p.Name.ToLower().Equals(parsedProperty.Name.ToLower(),
                    System.StringComparison.InvariantCulture)).ToList();

                if (properties.Count > 0)
                {
                    var property = properties[0];

                    if (!(parsedProperty.Value is Array))
                        property.SetValue(this, parsedProperty.Value);
                }
                else throw new RPTParserException("There are no propety with name: \"" 
                    + parsedProperty.Value.GetType().Name + "  " 
                    + parsedProperty.Name + "\" in class: " + this.GetType().Name);
            }
            catch (RPTParserException)
            {
                throw;
            }
            catch (Exception ex)
            {
                string message = string.Format("Could not bind property \"{0}\" " +
                    "to the object with type \"{1}\"\n{2}", parsedProperty.Name, this.GetType().Name, ex.Message);
                throw new RPTParserException(message, ex);
            }
        }
    }
}
