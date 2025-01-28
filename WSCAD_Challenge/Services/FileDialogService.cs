using Microsoft.Win32;

namespace WSCAD_Challenge.Services
{
    public class FileDialogService : IFileDialogService
    {
        public string OpenFile(string filter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
