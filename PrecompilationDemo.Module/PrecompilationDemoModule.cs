using System;
using StackExchange.Precompilation;

namespace PrecompilationDemo.Module
{
    public class PrecompilationDemoModule : ICompileModule
    {
        public void BeforeCompile(BeforeCompileContext context)
        {
            foreach (var syntaxTree in context.Compilation.SyntaxTrees)
            {
                var model = context.Compilation.GetSemanticModel(syntaxTree);
                var rewriter = new StringBuilderInterpolationOptimizer(model);
                var rootNode = syntaxTree.GetRoot();
                var rewritten = rewriter.Visit(rootNode);
                if (rootNode != rewritten)
                {
                    context.Compilation = context.Compilation.ReplaceSyntaxTree(
                        syntaxTree,
                        syntaxTree.WithRootAndOptions(rewritten, syntaxTree.Options));
                }
            }
        }

        public void AfterCompile(AfterCompileContext context)
        {
        }
    }
}
