﻿using System.Collections.ObjectModel;
using System.ComponentModel;

using LinqPad.Editor;

using OxyPlot;

namespace LinqPad.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private OpenDocumentViewModel currentDocumentViewModel;

        private ObservableCollection<OpenDocumentViewModel> openDocuments;

        private ObservableCollection<DocumentViewModel> documents;

        public MainViewModel()
        {
            this.OpenDocuments = new ObservableCollection<OpenDocumentViewModel>();
            this.documents = new ObservableCollection<DocumentViewModel>
            {
                new DocumentViewModel(@"C:\Users\Ivan\Documents\LinqPad\Samples", true)
            };

            this.ChartViewModel = new ChartViewModel();
            this.DataGridViewModel = new DataGridViewModel();

            LinqPadExtensions.Ploted += this.LinqPadExtensionsPloted;
            LinqPadExtensions.Tabled += this.LinqPadExtensionsTabled;
            if (!this.IsOpenAnyDocuments)
            {
                this.CreateDocument();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static string Title => "LinqPad";

        public LinqPadEditorHost LinqPadEditorHost { get; } = new LinqPadEditorHost();

        public ChartViewModel ChartViewModel { get; }

        public DataGridViewModel DataGridViewModel { get; }

        public ObservableCollection<DocumentViewModel> Documents
        {
            get
            {
                return this.documents;
            }

            set
            {
                if (this.documents == value)
                {
                    return;
                }

                this.documents = value;
                this.RaisePropertyChanged(nameof(this.Documents));
            }
        }

        public ObservableCollection<OpenDocumentViewModel> OpenDocuments
        {
            get
            {
                return this.openDocuments;
            }

            private set
            {
                if (value == this.openDocuments)
                {
                    return;
                }

                this.openDocuments = value;
                this.RaisePropertyChanged(nameof(this.OpenDocuments));
            }
        }

        public OpenDocumentViewModel CurrentDocumentViewModel
        {
            get
            {
                return this.currentDocumentViewModel;
            }

            set
            {
                if (value == this.currentDocumentViewModel)
                {
                    return;
                }

                this.currentDocumentViewModel = value;
                this.RaisePropertyChanged(nameof(this.CurrentDocumentViewModel));
            }
        }

        private bool IsOpenAnyDocuments => this.openDocuments.Count != 0;

        public void OpenDocument(DocumentViewModel source)
        {
            if (source.IsFolder)
            {
                return;
            }

            var doc = new OpenDocumentViewModel(this, source);
            this.openDocuments.Add(doc);
            this.CurrentDocumentViewModel = doc;
        }

        private void LinqPadExtensionsTabled(ResultTable<object> obj)
        {
            if (obj != null)
            {
                this.DataGridViewModel.AddTable(obj);
            }
        }

        private void LinqPadExtensionsPloted(PlotModel obj)
        {
            if (obj != null)
            {
                this.ChartViewModel.AddChart(obj);
            }
        }

        private void CreateDocument()
        {
            var document = new OpenDocumentViewModel(this, null);
            this.currentDocumentViewModel = document;
            this.openDocuments.Add(document);
        }

        private void RaisePropertyChanged(string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
