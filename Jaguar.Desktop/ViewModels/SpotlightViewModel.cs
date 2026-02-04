using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class SpotlightViewModel: ViewModelBase
{
    public ObservableCollection<SpotlightSlide> Slides { get; } = new();

    [ObservableProperty] private SpotlightSlide? _currentSlide;

    private int _currentIndex;
    private DispatcherTimer? _rotationTimer;

    public SpotlightViewModel()
    {
        
    }

    public void LoadSlides()
    {
        Slides.Clear();
        Slides.Add(new SpotlightSlide
        {
            Title = "Workflow Graph",
            SubTitle = "Design complex systems visually.",
            VisualSource = "avares://Assets/slide1.png",
            Duration = TimeSpan.FromSeconds(10)
        });
        
        Slides.Add(new SpotlightSlide
        {
            Title = "Agent Simulations",
            SubTitle = "Run multi-agents scenarios safely.",
            VisualSource = "avares://Assets/slide2.png",
            Duration = TimeSpan.FromSeconds(12)
        });

        _currentIndex = 0;
        CurrentSlide = Slides.FirstOrDefault();
    }

    public void StartRotation()
    {
        if(Slides.Count == 0) return;
        
        _rotationTimer?.Stop();

        _rotationTimer = new DispatcherTimer
        {
            Interval = CurrentSlide?.Duration ?? TimeSpan.FromSeconds(10)
        };

        _rotationTimer.Tick += (_, _) => MoveSlide();
        _rotationTimer.Start();
    }

    private void MoveSlide()
    {
        if(Slides.Count == 0) return;

        _currentIndex++;

        if (_currentIndex >= Slides.Count)
            _currentIndex = 0;

        CurrentSlide = Slides[_currentIndex];

        _rotationTimer.Interval = CurrentSlide.Duration;
    }
}