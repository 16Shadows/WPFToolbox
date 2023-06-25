using MVVMToolbox;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPFToolbox
{
    /// <summary>
    /// Wpf-specific implementation of IContext using Dispatcher
    /// </summary>
    public sealed class WPFContext : IContext
    {
        private readonly Dispatcher m_Dispatcher;
        public WPFContext(Dispatcher dispatcher)
        {
            m_Dispatcher = dispatcher;
        }

        public void BeginInvoke(Action callback)
        {
            m_Dispatcher.BeginInvoke(callback, null);
        }

        public void Invoke(Action callback)
        {
            try
            {
                m_Dispatcher.Invoke(callback);
            }
            catch(TaskCanceledException)
            {
                //Silently catch all task cancelations since they occur only when application is killed
            }
        }
    }
}
