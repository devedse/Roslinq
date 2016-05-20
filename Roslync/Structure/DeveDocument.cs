using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roslync.Structure
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