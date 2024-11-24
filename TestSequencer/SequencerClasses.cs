//using System;
//using System.Xml.Serialization;

//[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//[System.SerializableAttribute()]
//[System.Diagnostics.DebuggerStepThroughAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[XmlTypeAttribute(AnonymousType = true)]
//[XmlRootAttribute(Namespace = "", IsNullable = false)]
//public class TO {
//    [XmlElementAttribute("TG", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public TestGroup[] TG;
//    [XmlAttributeAttribute(DataType = "ID")] public String Folder;
//    [XmlAttributeAttribute()] public String Description;

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class TestGroup {
//        [XmlElementAttribute("MC", typeof(MethodCustom), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MI", typeof(MethodInterval), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MP", typeof(MethodProcess), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MT", typeof(MethodTextual), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public Object[] Items;
//        [XmlAttributeAttribute(DataType = "ID")] public String Class;
//        [XmlAttributeAttribute()] public String Description;
//        [XmlAttributeAttribute()] public Boolean CancelIfFail;
//        [XmlAttributeAttribute()] public Boolean Independent;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodCustom {
//        [XmlAttributeAttribute(DataType = "ID")] public String Method;
//        [XmlAttributeAttribute()] public String Description;
//        [XmlAttributeAttribute()] public Boolean CancelIfFail;
//        [XmlElementAttribute("Parameter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public MethodCustomParameter[] Parameter;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public class MethodCustomParameter {
//        [XmlAttributeAttribute()] public String Key;
//        [XmlAttributeAttribute()] public String Value;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodTextual {
//        [XmlAttributeAttribute(DataType = "ID")] public String Method;
//        [XmlAttributeAttribute()] public String Description;
//        [XmlAttributeAttribute()] public Boolean CancelIfFail;
//        [XmlAttributeAttribute()] public String Text;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodProcess {
//        [XmlAttributeAttribute(DataType = "ID")] public String Method;
//        [XmlAttributeAttribute()] public String Description;
//        [XmlAttributeAttribute()] public Boolean CancelIfFail;
//        [XmlAttributeAttribute()] public String Path;
//        [XmlAttributeAttribute()] public String Executable;
//        [XmlAttributeAttribute()] public String Parameters;
//        [XmlAttributeAttribute()] public String Expected;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodInterval {
//        [XmlAttributeAttribute(DataType = "ID")] public String Method;
//        [XmlAttributeAttribute()] public String Description;
//        [XmlAttributeAttribute()] public Boolean CancelIfFail;
//        [XmlAttributeAttribute()] public MethodIntervalLowComparator LowComparator;
//        [XmlAttributeAttribute()] public Double Low;
//        [XmlAttributeAttribute()] public Double High;
//        [XmlAttributeAttribute()] public MethodIntervalHighComparator HighComparator;
//        [XmlAttributeAttribute(DataType = "nonNegativeInteger")] public UInt32 FD;
//        [XmlAttributeAttribute()] public MethodIntervalPrefix Prefix;
//        [XmlIgnoreAttribute()] public Boolean PrefixSpecified;
//        [XmlAttributeAttribute()] public MethodIntervalUnits Units;
//        [XmlIgnoreAttribute()] public Boolean UnitsSpecified;
//        [XmlAttributeAttribute()] public MethodIntervalVoltAmpere VoltAmpere;
//        [XmlIgnoreAttribute()] public Boolean VoltAmpereSpecified;
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalLowComparator { GE, GT }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalHighComparator { LE, LT }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalPrefix { peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalUnits { Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalVoltAmpere { AC, DC, Peak, PP, RMS }
//}
