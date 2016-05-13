//_______________________________________________________________
//  Title   : AnimatedTabControl
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.Controls
{
  /// <summary>
  /// Custom Tab control with animations.
  /// </summary>
  /// <remarks>
  /// This customization of the TabControl was required to create the animations for the transition 
  /// between the tab items.
  /// </remarks>
  public class AnimatedTabControl : TabControl
  {

    public AnimatedTabControl()
    {
      DefaultStyleKey = typeof(AnimatedTabControl);
    }

    public static readonly RoutedEvent SelectionChangingEvent = EventManager.RegisterRoutedEvent("SelectionChanging", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(AnimatedTabControl));
    public event RoutedEventHandler SelectionChanging
    {
      add { AddHandler(SelectionChangingEvent, value); }
      remove { RemoveHandler(SelectionChangingEvent, value); }
    }

    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
      this.Dispatcher.BeginInvoke(
          (Action)delegate
          {
            this.RaiseSelectionChangingEvent();
            this.StopTimer();
            this.m_Timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 500) };
            EventHandler handler = (sender, args) =>
                                                     {
                                                       this.StopTimer();
                                                       base.OnSelectionChanged(e);
                                                     };
            this.m_Timer.Tick += handler;
            this.m_Timer.Start();
          });
    }
    private DispatcherTimer m_Timer;
    // This method raises the Tap event
    private void RaiseSelectionChangingEvent()
    {
      var args = new RoutedEventArgs(SelectionChangingEvent);
      RaiseEvent(args);
    }
    private void StopTimer()
    {
      if (this.m_Timer == null)
        return;
      this.m_Timer.Stop();
      this.m_Timer = null;
    }

  }
}