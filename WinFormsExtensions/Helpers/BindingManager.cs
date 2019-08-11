using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions.Helpers
{
    public class BindingEntity<T>
        where T : new()
    {
        public BindingEntity(Func<T> defaultValueFactory = null)
        {
            DefaultValueFactory = defaultValueFactory ?? (() => new T());
            New();
        }

        public BindingSource Source { get; private set; }

        private T _value { get; set; }
        public T Value
        {
            get => _value;
            private set
            {
                if (Source == null)
                { Source = new BindingSource() { DataSource = typeof(T) }; }

                _value = value;
                Source.DataSource = _value;
            }
        }

        #region Configuration
        private Func<T> DefaultValueFactory { get; set; }
        #endregion

        #region Public Methods
        public void New()
        { Value = DefaultValueFactory(); }

        public void LoadEntity(T entry)
        { Value = entry; }

        public void BindingControl<C, TPropery>(
            C control,
            Expression<Func<T, TPropery>> sourceProperty,
            Expression<Func<C, object>> controlProperty = null,
            bool formatingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            T defaulValue = default(T),
            string formatString = null
        )
            where C : Control, new ()
        {
            var binding = DataBinding.MakeBinding
            (
                Source,
                sourceProperty,
                controlProperty,
                formatingEnabled,
                dataSourceUpdateMode,
                defaulValue,
                formatString
            );

            control.DataBindings.Add(binding);
        }
        #endregion
    }
}
