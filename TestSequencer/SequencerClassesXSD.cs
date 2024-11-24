using System;
using System.Xml.Serialization;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType = true)]
[XmlRootAttribute(Namespace = "", IsNullable = false)]
public class TO {
    [XmlElementAttribute("TG", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public TestGroup[] TG;
    [XmlAttributeAttribute(DataType = "ID")] public String Folder { get; set; }
    [XmlAttributeAttribute()] public String Description { get; set; }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class TestGroup {
        [XmlElementAttribute("MC", typeof(MethodCustom), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElementAttribute("MI", typeof(MethodInterval), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElementAttribute("MP", typeof(MethodProcess), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElementAttribute("MT", typeof(MethodTextual), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Object[] Items { get; set; }
        [XmlAttributeAttribute(DataType = "ID")] public String Class { get; set; }
        [XmlAttributeAttribute()] public String Description { get; set; }
        [XmlAttributeAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlAttributeAttribute()] public Boolean Independent { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodCustom {
        [XmlAttributeAttribute(DataType = "ID")] public String Method { get; set; }
        [XmlAttributeAttribute()] public String Description { get; set; }
        [XmlAttributeAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlElementAttribute("Parameter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public MethodCustomParameter[] Parameter { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class MethodCustomParameter {
        [XmlAttributeAttribute()] public String Key { get; set; }
        [XmlAttributeAttribute()] public String Value { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodTextual {
        [XmlAttributeAttribute(DataType = "ID")] public String Method { get; set; }
        [XmlAttributeAttribute()] public String Description { get; set; }
        [XmlAttributeAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlAttributeAttribute()] public String Text { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodProcess {
        [XmlAttributeAttribute(DataType = "ID")] public String Method { get; set; }
        [XmlAttributeAttribute()] public String Description { get; set; }
        [XmlAttributeAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlAttributeAttribute()] public String Path { get; set; }
        [XmlAttributeAttribute()] public String Executable { get; set; }
        [XmlAttributeAttribute()] public String Parameters { get; set; }
        [XmlAttributeAttribute()] public String Expected { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodInterval {
        [XmlAttributeAttribute(DataType = "ID")] public String Method { get; set; }
        [XmlAttributeAttribute()] public String Description { get; set; }
        [XmlAttributeAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlAttributeAttribute()] public MethodIntervalLowComparator LowComparator { get; set; }
        [XmlAttributeAttribute()] public Double Low { get; set; }
        [XmlAttributeAttribute()] public Double High { get; set; }
        [XmlAttributeAttribute()] public MethodIntervalHighComparator HighComparator { get; set; }
        [XmlAttributeAttribute(DataType = "nonNegativeInteger")] public UInt32 FractionalDigits { get; set; }
        [XmlAttributeAttribute()] public MethodIntervalUnitPrefix UnitPrefix { get; set; }
        [XmlIgnoreAttribute()] public Boolean PrefixSpecified { get; set; }
        [XmlAttributeAttribute()] public MethodIntervalUnits Units { get; set; }
        [XmlIgnoreAttribute()] public Boolean UnitsSpecified { get; set; }
        [XmlAttributeAttribute()] public MethodIntervalUnitSuffix UnitSuffix { get; set; }
        [XmlIgnoreAttribute()] public Boolean UnitSuffixSpecified { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalLowComparator { GE, GT }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalHighComparator { LE, LT }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnitPrefix { peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnits { Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnitSuffix { AC, DC, Peak, PP, RMS }
}
