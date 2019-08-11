using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions
{
    public static class UIComponent
    {
        public static void WaitAction<C>(this C component, Action action)
            where C : ContainerControl, new()
        {
            try
            {
                component.Cursor = Cursors.WaitCursor;
                action();
            }
            catch (Exception ex)
            { DialogMessages.Exception(ex); }
            finally
            { component.Cursor = Cursors.Default; }
        }

        public static T WaitResult<C, T>(this C component, Func<T> action)
            where C: ContainerControl, new()
        {
            T result = default;
            component.WaitAction(() => result = action());
            return result;
        }
    }
}
