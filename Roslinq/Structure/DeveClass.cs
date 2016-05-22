using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roslinq.Structure
{
    public class DeveClass : DeveSyntaxNode
    {
        private ClassDeclarationSyntax _classDeclarationSyntax;

        public IEnumerable<DeveMethod> Methods => _classDeclarationSyntax.DescendantNodes().OfType<MethodDeclarationSyntax>().Select(t => new DeveMethod(t));

        public String Name
        {
            get
            {
                return _classDeclarationSyntax.Identifier.Value.ToString();
            }
        }

        public DeveDocument Parent { get; private set; }

        public DeveClass(ClassDeclarationSyntax classDeclarationSyntax, DeveDocument parent)
        {
            this._classDeclarationSyntax = classDeclarationSyntax;
            this.Parent = parent;
        }

        public void AddMethod(String methodText)
        {
            //var trreeee = SyntaxTree.ParseText(methodText).GetRoot();

            

            //var result = SyntaxAdderHelper.AddSyntaxNode(_classDeclarationSyntax, trreeee);
            //Parent.ReplaceThisChildNode(_classDeclarationSyntax, result);
            //_classDeclarationSyntax = result;
        }

        public override string ToString()
        {
            return _classDeclarationSyntax.ToString();
        }
    }
}