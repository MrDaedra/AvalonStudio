﻿namespace AvalonStudio.Controls.ViewModels
{
    using MVVM;
    using Projects;
    using ReactiveUI;
    using System;

    public class SolutionViewModel : ViewModel<ISolution>
    {
        public SolutionViewModel(ISolution model) : base(model)
        {
            //OpenInExplorerCommand = ReactiveCommand.Create();
            //OpenInExplorerCommand.Subscribe((o) =>
            //{
            //    Process.Start(model.CurrentDirectory);
            //});

            ConfigurationCommand = ReactiveCommand.Create();
            ConfigurationCommand.Subscribe((o) =>
            {
                //Workspace.Instance.ModalDialog = new SolutionConfigurationDialogViewModel(Workspace.Instance.SolutionExplorer.Model);
                //Workspace.Instance.ModalDialog.ShowDialog();
            });

            BuildSolutionCommand = ReactiveCommand.Create();
            BuildSolutionCommand.Subscribe((o) =>
            {
                BuildSolution();
            });

            CleanSolutionCommand = ReactiveCommand.Create();
            CleanSolutionCommand.Subscribe((o) =>
            {
                CleanSolution();
            });

            RebuildSolutionCommand = ReactiveCommand.Create();
            RebuildSolutionCommand.Subscribe((o) =>
            {
                CleanSolution();

                BuildSolution();
            });

            RunAllTestsCommand = ReactiveCommand.Create();
            RunAllTestsCommand.Subscribe((o) =>
            {
                RunTests();
            });
        }

        private async void CleanSolution()
        {
            // await Model.Solution.DefaultProject.SelectedConfiguration.ToolChain.Clean(Workspace.Instance.StudioConsole, Model.Solution.DefaultProject, Workspace.Instance.ProcessCancellationToken);
        }

        private async void BuildSolution()
        {
            //Workspace.Instance.SaveAllCommand.Execute(null);
            //await Model.Solution.DefaultProject.SelectedConfiguration.ToolChain.Build(Workspace.Instance.StudioConsole, this.Model.Solution.DefaultProject, Workspace.Instance.ProcessCancellationToken);
        }

        private async void RunTests()
        {
            //var testProjects = Model.Solution.LoadedProjects.OfType<CatchTestProject>();
            //var tests = new List<Test>();

            //foreach(var testProject in testProjects)
            //{
            //    await testProject.Build(Workspace.Instance.StudioConsole, Workspace.Instance.ProcessCancellationToken);

            //    tests.AddRange(testProject.EnumerateTests(Workspace.Instance.StudioConsole));            
            //}

            //Workspace.Instance.TestRunner.AddTests(tests);
            //Workspace.Instance.TestRunner.RunTests();

        }

        public ReactiveCommand<object> ConfigurationCommand { get; private set; }
        public ReactiveCommand<object> CleanSolutionCommand { get; private set; }
        public ReactiveCommand<object> BuildSolutionCommand { get; private set; }
        public ReactiveCommand<object> RebuildSolutionCommand { get; private set; }
        public ReactiveCommand<object> RunAllTestsCommand { get; private set; }

        new public string Title
        {
            get
            {
                if (Model != null)
                {
                    return string.Format("Solution '{0}' ({1} {2})", "SolutionTitle", Model.Projects.Count, StringProjects);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string StringProjects
        {
            get
            {
                if (Model.Projects.Count == 1)
                {
                    return "project";
                }
                else
                {
                    return "projects";
                }
            }
        }

        //public override bool CanAcceptDrop(Type type)
        //{
        //    bool result = false;

        //    if (type == typeof(StandardProjectViewModel))
        //    {
        //        result = true;
        //    }

        //    //if (type == typeof(TestProjectViewModel))
        //    //{
        //    //    result = true;
        //    //}

        //    if (type == typeof(SolutionFolderViewModel))
        //    {
        //        result = true;
        //    }

        //    return result;
        //}

        //public override void Drop(ProjectItemViewModel item)
        //{
        //    var project = item as ProjectViewModel;

        //    if (project != null)
        //    {
        //        var parent = project.Model.Solution.GetParent(project.Model);

        //        parent.RemoveItem(project.Model);

        //        Model.AttachItem(project.Model);
        //    }
        //    else if (item is SolutionFolderViewModel)
        //    {
        //        var folder = item as SolutionFolderViewModel;

        //        var parent = folder.Model.Solution.GetParent(folder.Model);

        //        parent.DetachItem(folder.Model);

        //        Model.AttachItem(folder.Model);
        //    }
        //}
    }
}
