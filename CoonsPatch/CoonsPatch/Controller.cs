using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoonsPatch
{
    public class Controller
    {
        public delegate void ModelChangeDelegate(object sender, ModelChangeEventArgs e);
        public delegate void SettingsChangeDelegate(object sender, RenderChangeEventArgs e);

        public event ModelChangeDelegate ModelChangeEvent;
        public event SettingsChangeDelegate RenderChangeEvent;

        public void RegisterView(IView view)
        {
            this.ModelChangeEvent += new ModelChangeDelegate(view.ModelChange);
        }

        public void UnregisterView(IView view)
        {
            this.ModelChangeEvent -= new ModelChangeDelegate(view.ModelChange);
        }

        public void RaiseModelChange(object sender, ModelChangeEventArgs e)
        {
            if (ModelChangeEvent != null)
                ModelChangeEvent(sender, e);
        }

        public void RaiseSettingsChange(object sender, RenderChangeEventArgs e)
        {
            if (RenderChangeEvent != null)
                RenderChangeEvent(sender, e);
        }

        internal void RegisterSettings(IRenderSettings renderForm)
        {
            this.RenderChangeEvent += new SettingsChangeDelegate(renderForm.RenderChange);
        }

        internal void UnregisterSettings(IRenderSettings renderForm)
        {
            this.RenderChangeEvent -= new SettingsChangeDelegate(renderForm.RenderChange);
        }
    }
}
