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

                    if (parsedProperty.Value is Array arrayy)
                    {
                        if (arrayy.Length.Equals(2))
                        {
                            var value0 = arrayy.GetValue(0);
                            var value1 = arrayy.GetValue(1);

                            if ((value0 is double || value0 is int) && (value1 is double || value1 is int))
                            {
                                property.SetValue(this,
                                    new Vector2(Convert.ToDouble(value0), Convert.ToDouble(value1))
                                    );
                            }
                            else throw new RPTParserException(string.Format("Values of the array {0} are not double or int", parsedProperty.Name));
                        }
                        else if (arrayy.Length.Equals(4))
                        {
                            var value0 = arrayy.GetValue(0);
                            var value1 = arrayy.GetValue(1);
                            var value2 = arrayy.GetValue(2);
                            var value3 = arrayy.GetValue(3);

                            if (
                                (value0 is double || value0 is int)
                                && (value1 is double || value1 is int)
                                && (value2 is double || value2 is int)
                                && (value3 is double || value3 is int)
                                )
                            {
                                property.SetValue(this,
                                    new Vector4(
                                        Convert.ToDouble(value0),
                                         Convert.ToDouble(value1),
                                         Convert.ToDouble(value2),
                                         Convert.ToDouble(value3)
                                    )
                                    );
                            }
                            else throw new RPTParserException(string.Format("Values of the array {0} are not double or int", parsedProperty.Name));

                        }
                        else throw new RPTParserException(string.Format("Not supported array type", parsedProperty.Name));
                    }
                    else
                    {
                        property.SetValue(this, parsedProperty.Value);
                    }
                }
                else throw new RPTParserException("There are no propety with name: \""
                    + parsedProperty.Value.GetType().Name + "  "
                    + parsedProperty.Name + "\" in class: " + this.GetType().Name);
            }
            catch (RPTParserException ex)
            {
                Console.WriteLine(ex.ToString());
                //throw;
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
