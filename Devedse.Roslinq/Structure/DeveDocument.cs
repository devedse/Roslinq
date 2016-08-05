using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devedse.Roslinq.Structure
{
    public class DeveDocument : DeveSyntaxNode
    {
        private Document _document;

        public IEnumerable<DeveClass> Classes => _document.GetSyntaxRootAsync().Result.DescendantNodes().OfType<ClassDeclarationSyntax>().Select(t => new DeveClass(t, this));
        public IEnumerable<DeveMethod> AllMethods => Classes.SelectMany(t => t.Methods);

        public String Name
        {
            get
            {
                return _document.Name;
            }
        }

        public IEnumerable<UsingDirectiveSyntax> Usings
        {
            get
            {
                return ((CompilationUnitSyntax)_document.GetSyntaxRootAsync().Result).Usings;
            }
        }

        public IEnumerable<string> UnusedUsings
        {
            get
            {
                var semanticModel = ((SemanticModel)_document.GetSemanticModelAsync().Result);
                //var ns = semanticModel.SyntaxTree.GetRoot().DescendantNodes().SelectMany(node => GetNamespaceSymbol(semanticModel.GetSemanticInfo(node).Symbol)).Distinct();

                var descNodes = semanticModel.SyntaxTree.GetRoot().DescendantNodes();

                foreach (var desc in descNodes)
                {
                    var thing1 = semanticModel.GetSymbolInfo(desc).Symbol;


                    if (thing1 != null)
                    {
                        var thing3 = thing1.ContainingNamespace;
                        yield return thing3.ToString();
                    }
                    else
                    {
                        //Console.WriteLine("No symbol found...");
                    }


                }
            }
        }



        private static IEnumerable<INamespaceSymbol> GetNamespaceSymbol(ISymbol symbol)
        {
            if (symbol != null && symbol.ContainingNamespace != null)
                yield return symbol.ContainingNamespace;
        }



        public DeveProject Parent { get; private set; }

        public DeveDocument(Document document, DeveProject parent)
        {
            Parent = parent;
            _document = document;
        }

        internal void ReplaceThisChildNode(ClassDeclarationSyntax oldDeclarationSyntax, ClassDeclarationSyntax newDeclarationSyntax)
        {
            var curSyntaxRoot = _document.GetSyntaxRootAsync().Result;
            var result = curSyntaxRoot.ReplaceNode(oldDeclarationSyntax, newDeclarationSyntax);

            //_document = _document.UpdateSyntaxRoot(result);

            //Parent.PropagateNewProject(_document.Project);
        }
    }
}