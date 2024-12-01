using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml.Serialization;
using Microsoft.CSharp;

namespace TestSequencer {

    public static class Generator {

        public static void Main() {
            TO to;
            using (FileStream fs = new FileStream(Properties.Resources.XML_File, FileMode.Open)) { to = (TO)(new XmlSerializer(typeof(TO))).Deserialize(fs); }

            CodeNamespace nameSpace = new CodeNamespace(to.Namespace);
            nameSpace.Imports.Add(new CodeNamespaceImport("System"));
            nameSpace.Imports.Add(new CodeNamespaceImport("System.Diagnostics"));
            nameSpace.Imports.Add(new CodeNamespaceImport("static TestSequencer.MethodAssertions"));
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            _ = compileUnit.Namespaces.Add(nameSpace);

            Boolean isFirstTOMethod = true;
            foreach (TG tg in to.TestGroups) {
                Boolean isFirstTGMethod = true;
                CodeTypeDeclaration classDeclaration = AddClass(nameSpace, tg);
                foreach (MethodShared ms in tg.Methods) {
                    AddMethod(classDeclaration, to, tg, ms, isFirstTOMethod, isFirstTGMethod);
                    isFirstTOMethod = isFirstTGMethod = false;
                }
            }
            GenerateCode(compileUnit, @"C:\Users\phill\Source\Repos\TestPlanConfig\TestSequencer\Generated.cs");
        }

        private static CodeTypeDeclaration AddClass(CodeNamespace nameSpace, TG tg) {
            CodeTypeDeclaration codeDeclaration = new CodeTypeDeclaration(tg.Class) {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.NotPublic | System.Reflection.TypeAttributes.Class,
            };
            _ = nameSpace.Types.Add(codeDeclaration);
            return codeDeclaration;
        }

        private static void AddMethod(CodeTypeDeclaration classDeclaration, TO to, TG tg, MethodShared ms, Boolean isFirstTOMethod, Boolean isFirstTGMethod) {
            CodeMemberMethod memberMethod = new CodeMemberMethod {
                Name = ms.Method,
                Attributes = MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(String))
            };
            if (isFirstTOMethod) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertion)to).Assertion()}"));
            if (isFirstTGMethod) _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertion)tg).Assertion()}"));
            _ = memberMethod.Statements.Add(new CodeSnippetStatement($"\t\t\t{((IAssertion)ms).Assertion()}"));
            _ = memberMethod.Statements.Add(new CodeSnippetStatement("\t\t\treturn String.Empty;"));
            _ = classDeclaration.Members.Add(memberMethod);
        }

        private static void GenerateCode(CodeCompileUnit compileUnit, String outputFileName) {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions {
                BlankLinesBetweenMembers = true,
                BracingStyle = "Block",
                IndentString = "    "
            };

            using (StreamWriter sourceWriter = new StreamWriter(outputFileName)) { provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options); }
        }
    }
}
