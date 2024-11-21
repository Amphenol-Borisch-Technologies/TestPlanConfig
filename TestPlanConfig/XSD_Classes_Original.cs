//using System;
//using System.Xml.Serialization;

//[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//[System.SerializableAttribute()]
//[System.Diagnostics.DebuggerStepThroughAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[XmlTypeAttribute(AnonymousType = true)]
//[XmlRootAttribute(Namespace = "", IsNullable = false)]
//public class TO {
//    [XmlElementAttribute("TG", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//    public TestGroup[] TG;

//    [XmlAttributeAttribute(DataType = "ID")]
//    public String Folder;

//    [XmlAttributeAttribute()]
//    public String Description;

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class TestGroup {

//        private object[] itemsField;

//        private String classField;

//        private String descriptionField;

//        private Boolean cancelIfFailField;

//        private Boolean independentField;


//        [XmlElementAttribute("MC", typeof(MethodCustom), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MI", typeof(MethodInterval), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MP", typeof(MethodProcess), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [XmlElementAttribute("MT", typeof(MethodTextual), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public object[] Items {
//            get {
//                return this.itemsField;
//            }
//            set {
//                this.itemsField = value;
//            }
//        }


//        [XmlAttributeAttribute(DataType = "ID")]
//        public String Class {
//            get {
//                return this.classField;
//            }
//            set {
//                this.classField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Description {
//            get {
//                return this.descriptionField;
//            }
//            set {
//                this.descriptionField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean CancelIfFail {
//            get {
//                return this.cancelIfFailField;
//            }
//            set {
//                this.cancelIfFailField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean Independent {
//            get {
//                return this.independentField;
//            }
//            set {
//                this.independentField = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodCustom {

//        private MethodCustomParameter[] parameterField;

//        private String methodField;

//        private String descriptionField;

//        private Boolean cancelIfFailField;


//        [XmlElementAttribute("Parameter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public MethodCustomParameter[] Parameter {
//            get {
//                return this.parameterField;
//            }
//            set {
//                this.parameterField = value;
//            }
//        }


//        [XmlAttributeAttribute(DataType = "ID")]
//        public String Method {
//            get {
//                return this.methodField;
//            }
//            set {
//                this.methodField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Description {
//            get {
//                return this.descriptionField;
//            }
//            set {
//                this.descriptionField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean CancelIfFail {
//            get {
//                return this.cancelIfFailField;
//            }
//            set {
//                this.cancelIfFailField = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public class MethodCustomParameter {

//        private String keyField;

//        private String valueField;


//        [XmlAttributeAttribute()]
//        public String Key {
//            get {
//                return this.keyField;
//            }
//            set {
//                this.keyField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Value {
//            get {
//                return this.valueField;
//            }
//            set {
//                this.valueField = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodTextual {

//        private String methodField;

//        private String descriptionField;

//        private Boolean cancelIfFailField;

//        private String textField;


//        [XmlAttributeAttribute(DataType = "ID")]
//        public String Method {
//            get {
//                return this.methodField;
//            }
//            set {
//                this.methodField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Description {
//            get {
//                return this.descriptionField;
//            }
//            set {
//                this.descriptionField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean CancelIfFail {
//            get {
//                return this.cancelIfFailField;
//            }
//            set {
//                this.cancelIfFailField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Text {
//            get {
//                return this.textField;
//            }
//            set {
//                this.textField = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodProcess {

//        private String methodField;

//        private String descriptionField;

//        private Boolean cancelIfFailField;

//        private String pathField;

//        private String executableField;

//        private String parametersField;

//        private String expectedField;


//        [XmlAttributeAttribute(DataType = "ID")]
//        public String Method {
//            get {
//                return this.methodField;
//            }
//            set {
//                this.methodField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Description {
//            get {
//                return this.descriptionField;
//            }
//            set {
//                this.descriptionField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean CancelIfFail {
//            get {
//                return this.cancelIfFailField;
//            }
//            set {
//                this.cancelIfFailField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Path {
//            get {
//                return this.pathField;
//            }
//            set {
//                this.pathField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Executable {
//            get {
//                return this.executableField;
//            }
//            set {
//                this.executableField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Parameters {
//            get {
//                return this.parametersField;
//            }
//            set {
//                this.parametersField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Expected {
//            get {
//                return this.expectedField;
//            }
//            set {
//                this.expectedField = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    public class MethodInterval {

//        private MethodIntervalLowComparator lowComparatorField;

//        private String methodField;

//        private String descriptionField;

//        private Boolean cancelIfFailField;

//        private Double lowField;

//        private Double highField;

//        private MethodIntervalHighComparator highComparatorField;

//        private String fdField;

//        private MethodIntervalPrefix prefixField;

//        private MethodIntervalUnits unitsField;

//        private MethodIntervalVA_Descriptor vA_DescriptorField;

//        private Boolean vA_DescriptorFieldSpecified;


//        [XmlAttributeAttribute()]
//        public MethodIntervalLowComparator LowComparator {
//            get {
//                return this.lowComparatorField;
//            }
//            set {
//                this.lowComparatorField = value;
//            }
//        }


//        [XmlAttributeAttribute(DataType = "ID")]
//        public String Method {
//            get {
//                return this.methodField;
//            }
//            set {
//                this.methodField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public String Description {
//            get {
//                return this.descriptionField;
//            }
//            set {
//                this.descriptionField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Boolean CancelIfFail {
//            get {
//                return this.cancelIfFailField;
//            }
//            set {
//                this.cancelIfFailField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Double Low {
//            get {
//                return this.lowField;
//            }
//            set {
//                this.lowField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public Double High {
//            get {
//                return this.highField;
//            }
//            set {
//                this.highField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public MethodIntervalHighComparator HighComparator {
//            get {
//                return this.highComparatorField;
//            }
//            set {
//                this.highComparatorField = value;
//            }
//        }


//        [XmlAttributeAttribute(DataType = "nonNegativeInteger")]
//        public String FD {
//            get {
//                return this.fdField;
//            }
//            set {
//                this.fdField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public MethodIntervalPrefix Prefix {
//            get {
//                return this.prefixField;
//            }
//            set {
//                this.prefixField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public MethodIntervalUnits Units {
//            get {
//                return this.unitsField;
//            }
//            set {
//                this.unitsField = value;
//            }
//        }


//        [XmlAttributeAttribute()]
//        public MethodIntervalVA_Descriptor VA_Descriptor {
//            get {
//                return this.vA_DescriptorField;
//            }
//            set {
//                this.vA_DescriptorField = value;
//            }
//        }


//        [XmlIgnoreAttribute()]
//        public Boolean VA_DescriptorSpecified {
//            get {
//                return this.vA_DescriptorFieldSpecified;
//            }
//            set {
//                this.vA_DescriptorFieldSpecified = value;
//            }
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalLowComparator {


//        GE,


//        GT,
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalHighComparator { LE, LT }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalPrefix {


//        peta,


//        tera,


//        giga,


//        mega,


//        kilo,


//        hecto,


//        deca,


//        [XmlEnumAttribute("")]
//        Item,


//        deci,


//        centi,


//        milli,


//        micro,


//        nano,


//        pico,


//        femto,
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalUnits {


//        [XmlEnumAttribute("")]
//        Item,


//        Amperes,


//        [XmlEnumAttribute("°Celcius")]
//        Celcius,


//        Farads,


//        Henries,


//        Hertz,


//        Ohms,


//        Seconds,


//        Siemens,


//        Volts,


//        VoltAmperes,


//        Watts,
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//    [System.SerializableAttribute()]
//    [XmlTypeAttribute(AnonymousType = true)]
//    public enum MethodIntervalVA_Descriptor {


//        AC,


//        DC,


//        Peak,


//        PP,


//        RMS,
//    }

//}