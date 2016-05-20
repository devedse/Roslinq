using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roslync.Structure
{
    public class DeveProject : DeveSyntaxNode
    {
        private Project _project;

        public IEnumerable<DeveDocument> Documents => _project.Documents.Select(t => new DeveDocument(t, this));
        public IEnumerable<DeveClass> AllClasses => Documents.SelectMany(t => t.Classes);
        public IEnumerable<DeveMethod> AllMethods => Documents.SelectMany(t => t.AllMethods);

        public String Name
        {
            get
            {
                return _project.Name;
            }
        }

        public DeveSolution Parent { get; private set; }

        public DeveProject(Project project, DeveSolution parent)
        {
            Parent = parent;
            _project = project;
        }

        internal void ReplaceThisChildNode(Document oldDocument, Document newDocument)
        {
            var newProject = _project.RemoveDocument(oldDocument.Id);
            IEnumerable<String> strrr = new List<String> { oldDocument.FilePath };

            var blah = _project.AddDocument(oldDocument.Name, newDocument.GetTextAsync().Result);

            newProject = blah.Project;
        }

        internal void PropagateNewProject(Project project)
        {
            this._project = project;
            Parent.PropagateNewSolution(_project.Solution);
        }
    }
}