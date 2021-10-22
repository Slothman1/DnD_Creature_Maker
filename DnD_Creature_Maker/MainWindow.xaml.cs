using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using WinRT;
using System.Runtime.InteropServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DnD_Creature_Maker
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        #region imported code
        [ComImport]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this method is a band aid fos for an issue with WINui where as far as i know there isn't a good
        /// open file pciekr dialog thing, this was present in winforms just not here
        /// this opens the file in a storgae file format which will need to later be converted to string for the json desrialization
        /// </summary>
        /// <param name="sender"></param>
        /// i believe this sends the infor to the xaml
        /// <param name="e"></param>
        /// E
        private  async void LoadJson(object sender, RoutedEventArgs e)
        {

            FileOpenPicker picker = new FileOpenPicker();
            var hwnd = this.As<IWindowNative>().WindowHandle;
            var InitializewithWindow = picker.As<IInitializeWithWindow>();
            InitializewithWindow.Initialize(hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".json");

            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                //IBuffer buffer = await FileIO.ReadBufferAsync(file);
                //string filestring = Convert.ToBase64String(buffer.ToArray());
                Input.LoadData(file.Path);
            }
        }
        
    }
}
