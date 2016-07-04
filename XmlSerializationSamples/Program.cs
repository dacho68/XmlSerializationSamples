using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerializationSamples
{
  class Program
  {
    public static DataDefinition LoadParameterDefinition(string iFullFilePath)
    {
      try
      {
        // Create a new XmlSerializer instance with the type of the ParameterMapTable class
        var wSerializerObj = new XmlSerializer(typeof(DataDefinition));

        DataDefinition wLoadedObj = null;

        // Create a new file stream for reading the XML file
        using (var wReadFileStream = new FileStream(iFullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
          // Create the object saved above by using the Deserialize function
          wLoadedObj = (DataDefinition)wSerializerObj.Deserialize(wReadFileStream);
          wReadFileStream.Close();
        }

        return wLoadedObj;
      }
      catch (Exception exception)
      {
        return null;
      }
    }

    static void Main(string[] args)
    {
      var wDataDef = LoadParameterDefinition(@"./ParamDef.xml");
      Console.WriteLine( wDataDef.ParameterDefs.Count);
      Console.WriteLine(wDataDef.EnumDefs.Count);
      Console.WriteLine(wDataDef.EnumDefs[0].Enumeration.Length);
      Console.ReadLine();

    }
  }
}
