using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerializationSamples
{
  /// <remarks/>
  [DataContract(Namespace = "http://schemas.cae.com/ng-system")]
  [Serializable]
  public class DataDefinition
  {
    /// <remarks/>
    public List<EnumDef> EnumDefs { get; set; }

    public List<ParameterDef> ParameterDefs { get; set; }

    public ParameterDef IsExistParameter(string iParamName)
    {
      var wParamDef = ParameterDefs.Find(x => x.Name.Equals(iParamName));
      if (wParamDef != null) return wParamDef;
      return null;
    }
  }

  [Serializable]
  public partial class EnumValue
  {
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlTextAttribute()]
    public double Value { get; set; }
  }

  /// <remarks/>
  /// 
  [Serializable]
  public partial class EnumDef
  {
    /// <remarks/>
    [XmlAttribute("name")]
    public string Name { get; set; }


    [XmlArray("Enum")]
    [XmlArrayItem("Value")]
    public EnumValue[] Enumeration { get; set; }
  }

  /// <remarks/>
  /// 
  [Serializable]
  public partial class ParameterDef
  {
    /// <remarks/>
    [XmlAttribute("name")]
    public string Name { get; set; }

    ///// <remarks/>
    //[System.Xml.Serialization.XmlAttributeAttribute()]
    //[XmlElement("enumDef")]
    //public string EnumDef { get; set; }

    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value { get; set; }
  }

}
