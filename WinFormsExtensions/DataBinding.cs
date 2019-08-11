using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions
{
    public static class DataBinding
    {
        internal static Binding MakeBinding<C, T, TProperty>(
            object source,
            Expression<Func<T, TProperty>> sourceProperty,
            Expression<Func<C, object>> controlProperty = null,
            bool formatingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            object defaulValue = default,
            string formatString = null
        )
            where C : Control, new()
        {
            string propertyName = null;

            if (controlProperty == null)
            {
                if (typeof(C).HasProperty("Value"))
                { propertyName = "Value"; }
                else if (typeof(C).HasProperty("Text"))
                { propertyName = "Text"; }
            }
            else
            { propertyName = controlProperty.GetPropertyName(); }

            if (string.IsNullOrWhiteSpace(propertyName))
            { throw new ArgumentNullException($"El argumento '{nameof(controlProperty)}' no genera una cadena valida", nameof(controlProperty)); }

            var dataMember = sourceProperty.GetPropertyName();
            if (string.IsNullOrWhiteSpace(propertyName))
            { throw new ArgumentNullException($"El argumento '{nameof(sourceProperty)}' no genera una cadena valida", nameof(sourceProperty)); }

            return new Binding(
                propertyName,
                source,
                dataMember,
                formatingEnabled,
                dataSourceUpdateMode,
                defaulValue,
                formatString
            );
        }

        public static void AddBinding<C, T, TProperty>(
            this C control,
            T source,
            Expression<Func<T, TProperty>> sourceProperty,
            Expression<Func<C, object>> controlProperty = null,
            bool formatingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            TProperty defaulValue = default,
            string formatString = null
        )
            where C : Control, new()
        {
            control.DataBindings.Add(
                MakeBinding(
                    source,
                    sourceProperty,
                    controlProperty,
                    formatingEnabled,
                    dataSourceUpdateMode,
                    defaulValue,
                    formatString
                )
            );
        }
    }
}
