using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Constants;
using Jaguar.Core.Models.Templates;
using Jaguar.Desktop.Services.Events.Ui;

namespace Jaguar.Desktop.ViewModels.Templates;

public partial class AgentTemplatesViewModel : ViewModelBase
{
    private readonly IAgentTemplateRepository _agentRepository;
    private readonly IEventAggregator _eventAggregator;
    public ObservableCollection<AgentTemplate> AvailableTemplates { get; }
    
    private readonly IServiceProvider _serviceProvider;
    
    public AgentTemplatesViewModel(IServiceProvider serviceProvider, IAgentTemplateRepository agentTemplateRepository, IEventAggregator eventAggregator)
    {
        _agentRepository = agentTemplateRepository;
        _eventAggregator = eventAggregator;
        _serviceProvider = serviceProvider;

        // Seed Template to DB.
        // SeedTemplates();
        
        // Initialize templates from static helper
        var templates = _agentRepository.GetAll().GetAwaiter().GetResult();
        AvailableTemplates = new ObservableCollection<AgentTemplate>(templates.AsEnumerable());
    }

    private void SeedTemplates()
    {
        var defaultTemplates = AgentTemplates.DefaultAgentTemplates;

        foreach (var template in defaultTemplates)
        {
            _agentRepository.Update(template);

            Console.WriteLine($"--- Agent Template {template.Id} - {template.Type} added. ---");
        }
    }

    [RelayCommand]
    public void AddTemplate(AgentTemplate newTemplate)
    {
        _agentRepository.Add(newTemplate);
    }
    
    [RelayCommand]
    private void AddNode(string id) => _eventAggregator.Publish(new AddNodeEvent(id));
}