using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml.Serialization;
using Microsoft.CSharp;

namespace TestSequencer {

    public static class Generator {
        private const String INDENTATION = "    ";

        public static void Main() {
            XmlSerializer serializer = new XmlSerializer(typeof(TO));
            FileStream fs = new FileStream(Properties.Resources.XML_File, FileMode.Open);
            TO to = (TO)serializer.Deserialize(fs);
            fs.Close(); fs.Dispose();

            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace nameSpace = new CodeNamespace(to.Namespace);
            _ = compileUnit.Namespaces.Add(nameSpace);

            nameSpace.Imports.Add(new CodeNamespaceImport("System"));
            nameSpace.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            nameSpace.Imports.Add(new CodeNamespaceImport("static TestSequencer.MethodAssertions"));

            foreach (TG tg in to.TestGroups) {
                CodeTypeDeclaration classDeclaration = AddClass(nameSpace, tg);
                foreach(MethodShared ms in tg.Methods) AddMethod(classDeclaration, ms);
            }
            GenerateCSharpCode(compileUnit, @"C:\Users\phill\Source\Repos\TestPlanConfig\TestSequencer\Generated.cs");
        }

        private static CodeTypeDeclaration AddClass(CodeNamespace nameSpace, TG tg) {
            CodeTypeDeclaration ctd = new CodeTypeDeclaration(tg.Class) {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.NotPublic | System.Reflection.TypeAttributes.Class,
            };
            _ = nameSpace.Types.Add(ctd);
            return ctd;
        }

        private static void AddMethod(CodeTypeDeclaration classDeclaration, MethodShared ms) {
            CodeMemberMethod cmm = new CodeMemberMethod {
                Name = ms.Method,
                Attributes = MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(String))
            };
            String s = null;
            if (ms is MC mc) s = mc.Assertion();
            if (ms is MI mi) s = mi.Assertion();
            if (ms is MP mp) s = mp.Assertion();
            if (ms is MT mt) s = mt.Assertion();
            if (String.IsNullOrEmpty(s)) throw new NotImplementedException($"Method '{ms.Method}', Description '{ms.Description}' not implemented.");
            _ = cmm.Statements.Add(new CodeSnippetStatement($"\t\t\t{s}"));
            _ = cmm.Statements.Add(new CodeSnippetStatement("\t\t\treturn String.Empty;"));
            _ = classDeclaration.Members.Add(cmm);
        }

        private static void GenerateCSharpCode(CodeCompileUnit compileUnit, String outputFileName) {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions {
                BlankLinesBetweenMembers = true,
                BracingStyle = "Block",
                IndentString = INDENTATION
            };

            using (StreamWriter sourceWriter = new StreamWriter(outputFileName)) { provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options); }
        }
    }
}
