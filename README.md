# XmlSerializationSamples

This example demontrade of how to map xml attribute name, element name and array element name to C# Class with the XML serialization.

## Xml
``` xml
<DataDefinition>
	<MajorVersion>1</MajorVersion>
	<MinorVersion>0</MinorVersion>
	<!-- You can use this is the TE definition such as   BreakingAction == BAType.Good   -->
	<EnumDefs>
		<EnumDef name="BAType">
			<Enum>
				<Value name="Undefined">0</Value>
				<Value name="Good">1</Value>
				<Value name="Medium-Good">2</Value>
				<Value name="Medium">3</Value>
				<Value name="Medium-Poor">4</Value>
				<Value name="Poor">5</Value>
			</Enum>
		</EnumDef>
	</EnumDefs>


	<ParameterDefs>
		<ParameterDef name="BreakingAction" ></ParameterDef>
		<ParameterDef name="PressureAltitude" ></ParameterDef>
		<ParameterDef name="PitchAngle" ></ParameterDef>
	</ParameterDefs>
</DataDefinition>
```

## CSharp code
``` java
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
```