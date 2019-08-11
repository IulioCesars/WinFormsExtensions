using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsExtensions
{
    public class DialogMessages
    {
        public static void Exception<E>(E ex, string caption = null)
            where E :Exception
        {
            MessageBox.Show(
                ex.GetBaseException().Message, 
                string.IsNullOrWhiteSpace(caption) ? typeof(E).Name : caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1
            );
        }

        public static void Information(string content, string caption = "Information")
        {
            MessageBox.Show(
                content,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
            );
        }

        public static bool Question(string content, string caption = "Question")
        {
            return MessageBox.Show(
                content,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;
        }

        public static bool Warning(string content, string caption = "Warning")
        {
            return MessageBox.Show(
                content,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;
        }
    }
}
