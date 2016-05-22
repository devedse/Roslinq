using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devedse.Roslinq.Structure
{
    public class DeveMethod : DeveSyntaxNode
    {
        private MethodDeclarationSyntax _methodDeclarationSyntax;

        public String Name
        {
            get
            {
                return _methodDeclarationSyntax.Identifier.ToString();
            }
        }

        public String InnerCode
        {
            get
            {
                return _methodDeclarationSyntax.ToString();
            }
        }

        public DeveMethod(MethodDeclarationSyntax methodDeclarationSyntax)
        {
            this._methodDeclarationSyntax = methodDeclarationSyntax;
        }
    }
}
