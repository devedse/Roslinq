using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roslync.Structure.Extra
{
    public static class SyntaxAdderHelper
    {
        public static ClassDeclarationSyntax AddSyntaxNode(ClassDeclarationSyntax parent, SyntaxNode child)
        {
            child = child.NormalizeWhitespace();

            List<MemberDeclarationSyntax> syntaxLijstje = new List<MemberDeclarationSyntax>();

            syntaxLijstje.AddRange(parent.ChildNodes().OfType<MemberDeclarationSyntax>());

            syntaxLijstje.AddRange(child.ChildNodes().OfType<MemberDeclarationSyntax>());

            var syntaxList = new SyntaxList<MemberDeclarationSyntax>();
            syntaxList.AddRange(syntaxLijstje);

            var result = parent.WithMembers(syntaxList).NormalizeWhitespace();

            return result;
        }
    }
}
