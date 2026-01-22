using System.Text.Json;
using System.Text.Json.Serialization;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Models;
using Jaguar.Core.Models.Graph;

namespace Jaguar.Core.Services;

public class ProjectService : IProjectService
{
    private const string JaguarProjectFileName = "jaguar.project.json";
    private const string JaguarAppVersion = "1.0.0";

    private readonly string _rootPath;
    private readonly string _projectsPath;

    public ProjectService()
    {
        _rootPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData
                )
        );

        _projectsPath = Path.Combine(_rootPath, "Jaguar", "Projects");
    }
    
    public List<Project> GetAllProjects()
    {
        Console.WriteLine(_projectsPath);
        List<Project> results = new List<Project>();

        foreach (var dir in Directory.EnumerateDirectories(_projectsPath))
        {
            Console.WriteLine(dir);
            var projectFile = Path.Combine(dir, JaguarProjectFileName);
            
            if (!File.Exists(projectFile))
                continue;

            try
            {
                var json = File.ReadAllText(projectFile);
                var metadata = JsonSerializer.Deserialize<ProjectMetadata>(json);

                if (metadata?.Name == null)
                    continue;
                
                results.Add(
                    new Project
                    {
                        Name = metadata.Name,
                        Path = dir
                    }
                    );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        return results;
    }

    public Project CreateProject(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name is required.", nameof(name));


        var safeName = MakeSafeFolderName(name);
        var projectDir = Path.Combine(_projectsPath, safeName);

        Console.WriteLine(projectDir);
        if (Directory.Exists(projectDir))
            throw new InvalidOperationException($"A project with this name already exists. {safeName}");

        Directory.CreateDirectory(projectDir);
        Directory.CreateDirectory(Path.Combine(projectDir, "agents"));
        Directory.CreateDirectory(Path.Combine(projectDir, "graph"));
        Directory.CreateDirectory(Path.Combine(projectDir, "tasks"));
        Directory.CreateDirectory(Path.Combine(projectDir, "state"));
        Directory.CreateDirectory(Path.Combine(projectDir, "tests"));

        var orchestratorNode = new FlowNodeMetadata { Type = NodeType.Orchestrator };

        var options = new JsonSerializerOptions()
        {
            AllowDuplicateProperties = false,
            WriteIndented = true,
        };
          
        options.Converters.Add(new JsonStringEnumConverter());
        var nodeJson = JsonSerializer.Serialize(new List<FlowNodeMetadata>{orchestratorNode} ,options);
        
        File.WriteAllText(Path.Combine(projectDir, "graph", "nodes.json"), nodeJson);

        var metadata = new ProjectMetadata
        {
            Name = name,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
            SchemaVersion = 1,
            JaguarVersion = JaguarAppVersion
        };

        var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions()
        {
            AllowDuplicateProperties = false,
            WriteIndented = true,
        });
        
        File.WriteAllText(Path.Combine(projectDir, JaguarProjectFileName), json);

        return new Project
        {
            Name = name,
            Path = projectDir,
            Description = ""
        };
    }

    public List<FlowNode> GetProjectNodes(string projectName)
    {
        if (String.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Project Name is required.", nameof(projectName));
        
        List<FlowNode> results = new List<FlowNode>();

        var projectDir = Path.Combine(_projectsPath, projectName);

        if (Directory.Exists(projectDir))
        {
            var graphDir = Path.Combine(projectDir, "graph", "nodes.json");

            try
            {
                if (File.Exists(graphDir))
                {
                    var nodeJson = File.ReadAllText(graphDir);

                    var metaData = JsonSerializer.Deserialize<List<FlowNodeMetadata>>(nodeJson);

                    if (metaData is not null)
                    {
                        foreach (var node in metaData)
                        {
                            results.Add(new FlowNode
                            {
                                Type = node.Type
                            });

                            Console.WriteLine($"---> Adding Node: {node.Id}, type: {node.Type}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Getting Nodes Error.");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        return results;
    }

    private static string MakeSafeFolderName(string name)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }

        return name.Trim();
    }
}