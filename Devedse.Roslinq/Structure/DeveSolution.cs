using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Devedse.Roslinq.Structure
{
    public class DeveSolution
    {
        private Solution _solution;
        private MSBuildWorkspace _workspace;

        public IEnumerable<DeveProject> Projects => _solution.Projects.Select(t => new DeveProject(t, this));
        public IEnumerable<DeveDocument> AllDocuments => Projects.SelectMany(t => t.Documents);
        public IEnumerable<DeveClass> AllClasses => Projects.SelectMany(t => t.AllClasses);
        public IEnumerable<DeveMethod> AllMethods => Projects.SelectMany(t => t.AllMethods);

        public DeveSolution(string sln)
        {
            _workspace = MSBuildWorkspace.Create();
            _solution = _workspace.OpenSolutionAsync(sln).Result;
        }

        internal void PropagateNewSolution(Solution solution)
        {
            _solution = solution;
        }

        internal Boolean SaveToDisk()
        {
            var success = _workspace.TryApplyChanges(_solution);

            if (success)
            {
                Console.WriteLine("Successfully written solution :)");
            }

            return success;
        }
    }
}